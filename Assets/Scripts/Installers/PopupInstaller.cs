using UnityEngine;
using Zenject;

namespace Lessons.Architecture.PM
{
    public class PopupInstaller : MonoInstaller
    { 
        public override void InstallBindings()
        {
            Container.Bind<PopupPresenterFactory>().AsSingle().NonLazy();
        }
    }
}