# Bootstrapper

Prism.UnityによるBootstarapperのサンプル

## MEMO

- Prism.Unity.UnityBootstrapperを継承して、Bootstrapperクラスを作成する
- Bootstapper.ConfigureModuleCatalogメソッド内で、この後作成するモジュールを追加する
- Prism.Modularity.IModuleを継承して、Moduleを作成する
- IModule.Initialize内で、ModelとViewをUnitiyContainerに登録する
- ViewとViewModelは、Prism.Mvvm.ViewModelLocatorで紐づける
