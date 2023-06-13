using AutoMapper;
using System.Reflection;

namespace PresenterService.Application.Common.Mappings;

public class AssemblyMappigProfile : Profile
{
    public AssemblyMappigProfile(Assembly assembly)
        => ApplyMappingsFromAssembly(assembly);

    void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(type => type.GetInterfaces()
                .Any(i => i.IsGenericType &&
                          i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
            .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod("Mapping");
            methodInfo?.Invoke(instance, new object[] { this });
        }
    }
}
