# PrismSample

## BootstrapperSampleプロジェクト

Prism.UnityによるBootstarapperのサンプル

### プロジェクト構成

- BootstrapperSample
    - HelloWorldModule

### 要点

- Prism.Unity.UnityBootstrapperを継承して、Bootstrapperクラスを作成する
- Bootstapper.ConfigureModuleCatalog内でモジュールを追加する
- Prism.Modularity.IModuleを継承して、モジュールクラスを作成する
- IModule.Initialize内で、ModelとViewをUnitiyContainerに登録する
- ViewとViewModelは、Prism.Mvvm.ViewModelLocatorで紐づける

