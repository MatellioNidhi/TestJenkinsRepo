using Inseego.Repositories.ServiceClient.Model;
using Inseego.Utilities.CacheExtension;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace VehicleMaintenceService.API.Helpers
{
    public static class JsonExtensions
    {
        public static JToken FindAndReplace(JToken jToken, List<LocalisationModel> response)
        {
            foreach (var item in response)
            {
                jToken.FindTokens(item.Key, item.Value);
            }

            return jToken;
        }

        private static void FindTokens(this JToken containerToken, string name, JToken value)
        {
            if (containerToken.Type == JTokenType.Object)
            {
                foreach (JProperty child in containerToken.Children<JProperty>())
                {
                    if (child.Value.ToString().Contains(name))
                    {
                        string pattern = @"\b" + name + @"\b";
                        try
                        {
                            child.Value = JsonConvert.DeserializeObject<JToken>(Regex.Replace(child.Value.ToString(), pattern, value.ToString()));
                        }
                        catch (Exception)
                        {
                            child.Value = Regex.Replace(child.Value.ToString(), pattern, value.ToString());
                        }
                    }
                    FindTokens(child.Value, name, value);
                }
            }
            else if (containerToken.Type == JTokenType.Array)
            {
                foreach (JToken child in containerToken.Children())
                {
                    FindTokens(child, name, value);
                }
            }
        }
    }
}
