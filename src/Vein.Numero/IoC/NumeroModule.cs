using Autofac;
using System;
using System.Linq;
using Vein.Numero.Abstractions;

namespace Vein.Numero.IoC
{
    public class NumeroModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            var types = assemblies
                .SelectMany(t => t.GetTypes())
                .Where(t => t.Name.StartsWith("Numero") && t.Name.EndsWith("Converter") && t.IsClass && !t.IsAbstract);

            foreach (var type in types)
            {
                builder.RegisterType(type)
                   .Keyed<INumeroConverter>(type.Name)
                   .WithMetadata<NumeroConverterMetadata>(m => m.For(ncm => ncm.Key, type.Name))
                   .As<INumeroConverter>();
            }

            builder.Register<Func<string, int, INumeroConverter>>(c => {
                var context = c.Resolve<IComponentContext>();
                return (key, number) => {
                    return context.ResolveKeyed<INumeroConverter>(key, new TypedParameter(typeof(int), number));
                };
            });

            builder.RegisterType<ConverterFactory>().As<IConverterFactory>();
        }
    }
}
