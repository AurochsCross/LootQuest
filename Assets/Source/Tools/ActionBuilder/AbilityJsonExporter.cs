using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Tools.ActionBuilder
{
    public class AbilityJsonExporter
    {
        public string GenerateActionJson(Nodes.ActionNode actionOutputNode) {
            var effectNodes = actionOutputNode.GetEffectNodes();

            var effects = effectNodes.Select(x => x.GetActionEffect()).ToArray();

            var action = new ActionRoot();
            action.effects = effects;
            action.id = actionOutputNode.graph.GetInstanceID();
            action.name = actionOutputNode.actionName;
            action.description = actionOutputNode.actionDescription;

            MemoryStream stream = new MemoryStream();  
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ActionRoot));
            serializer.WriteObject(stream, action);
            stream.Position = 0;

            StreamReader reader = new StreamReader(stream);
            var result = reader.ReadToEnd();

            Debug.Log("Json: ");  
            Debug.Log(reader.ReadToEnd());  

            return result;
        }
    }
}
