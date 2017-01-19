using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace beeless
{
    class Program
    {
        static void Main(string[] args)
        {
            ModuleDefMD module = ModuleDefMD.Load(args[0]);
            int fields = 0;
            int properties = 0;
            foreach (var type in module.Types)
            {
                var methods = 0;
                foreach (var method in type.Methods)
                {
                    if (method.Name.Length > 10)
                    {
                        method.Name = "method_" + methods;
                        methods++;
                    }

                    var paramaters = 0;
                    foreach (var paramater in method.Parameters)
                    {
                        if (paramater.Name.Length > 10)
                        {
                            paramater.Name = "param_" + paramaters;
                            paramaters++;
                        }
                    }
                }

                foreach (var field in type.Fields)
                {
                    if (field.Name.Length > 10)
                    {
                        field.Name = "field_" + fields;
                        fields++;
                    }
                }

                foreach (var property in type.Properties)
                {
                    if (property.Name.Length > 10)
                    {
                        property.Name = "property_" + properties;
                        properties++;
                    }
                }
            }
            module.Write(Path.GetFileNameWithoutExtension(args[0]) + "_cleaned" + Path.GetExtension(args[0]));
        }
    }
}
