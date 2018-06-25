# PrismSample

## 1. BootstrapperSampleプロジェクト

Prism.UnityによるBootstarapperのサンプル

### Bootstrapperポイント

- Prism.Unity.UnityBootstrapperを継承して、Bootstrapperクラスを作成する
- Bootstapper.ConfigureModuleCatalogメソッド内で、この後作成するモジュールを追加する
- Prism.Modularity.IModuleを継承して、モジュールクラスを作成する
- IModule.Initialize内で、ModelとViewをUnitiyContainerに登録する
- ViewとViewModelは、Prism.Mvvm.ViewModelLocatorで紐づける

## 2. InteractionRequestAppプロジェクト

InteractionRequestを用いたダイアログ表示のサンプル

### Module

- NotificationModule
- ConfirmationModule
- CustomModule
- DefaultDialogModule


### Memo

- InteractionRequestはMessengerパターンにおけるMessegerクラス
- Notification, ConfirmationはMessengerパターンにおけるMessageクラス
- Notificationは、「OK」ボタンのみ
- Confirmationは、「OK」「Cancel」ボタン
- InteractionRequest.RaiseAsyncメソッドは廃止されたっぽい [#672](https://github.com/PrismLibrary/Prism/issues/678)
