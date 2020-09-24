using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Inseego.Utilities
{
    public class CastSchema <TInput>
    {
        public List<Schema> CastData(TInput request) 
        {
            List<Schema> schemas = new List<Schema>();
            foreach (PropertyInfo p in typeof(TInput).GetProperties())
            {
                schemas.Add(new Schema
                {
                    field = p.Name,
                    title = p.Name
                });

            }
            return schemas;
        }

    }


    public class Schema
    {
        public string title { get; set; }
        public string field { get; set; }
        public bool hidden { get; set; } = false;

    }
}
