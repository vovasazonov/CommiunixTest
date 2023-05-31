using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Osyacat.Ecs;
using Osyacat.Ecs.Component.Component;
using Osyacat.Ecs.EntitasEcs;
using Osyacat.Ecs.Entity;
using Osyacat.Ecs.System;
using Osyacat.Ecs.World;
using Zenject;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs
{
    public class EcsArchitectureInstaller : Installer<EcsArchitectureInstaller>
    {
        public override void InstallBindings()
        {
            var universe = new EntitasEcsUniverse(GetEcsComponents());
            Container.Bind<IEcsUniverse>().FromInstance(universe);
            Container.Bind<IWorld>().FromInstance(universe.World);
            Container.Bind<ISystems>().FromInstance(universe.Systems);
            Container.Bind<SystemsAdder>().AsSingle().NonLazy();
        }

        private Type[] GetEcsComponents()
        {
            Type componentType = typeof(ComponentAttribute);
            Assembly assembly = Assembly.GetExecutingAssembly();
            return assembly.GetTypes()
                .Where(t => t.CustomAttributes.Any(a => a.AttributeType == componentType))
                .Concat(new[] { typeof(ViewComponent) })
                .ToArray();
        }

        private class SystemsAdder
        {
            public SystemsAdder(
                ISystems systemCollection,
                List<ISystem> systemsList
            )
            {
                foreach (var system in systemsList)
                {
                    systemCollection.Add(system);
                }
            }
        }
    }
}