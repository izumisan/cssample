# LoadModule

- PrismのModule読み込み順序の制御
- モジュール内クラスのコンテナへの自動登録

## Module

- LoadModuleApp
    - Shell, Bootstrapperを有するWPFアプリケーション
- LoaderModule
    - FooModuleを呼び出すモジュール
- MonitorModule
- FooModule
    - オンデマンドでロードするモジュール

## Note

- モジュールカタログにモジュールを追加する時（IModuleCatalog.AddModule()）、ロードタイミング（スタートアップ or オンデマンド）や依存モジュールを指定する

    ```cs
    protected override void ConfigureModuleCatalog()
    {
        var moduleCatalog = (ModuleCatalog)ModuleCatalog;

        // LoaderModuleの依存先にMonitorModuleを指定
        // MonitorModule→LoaderModuleの順に読み込まれる.
        moduleCatalog.AddModule( typeof( LoaderModule.LoaderModule ), nameof( MonitorModule.MonitorModule ) );

        // LoaderModuleより後にAddModuleしているが、LoaderModuleより先に読み込まれる
        moduleCatalog.AddModule( typeof( MonitorModule.MonitorModule ) );

        // オンデマンドで読み込まれる
        moduleCatalog.AddModule( typeof( FooModule.FooModule ), InitializationMode.OnDemand );
    }
    ```

- IModuleManager.LoadModule()でモジュールをロードする

    ```cs
    private void loadFooCommandExecute()
    {
        this.ModuleManager.LoadModule( "FooModule" );
    }
    ```

- コンテナへの自動登録

    ```cs
    // modelの登録
    _container.RegisterTypes(
        AllClasses.FromAssemblies( typeof( MonitorModule ).Assembly )
            .Where( x => x.Namespace.EndsWith( ".Models" ) ),
        getFromTypes: WithMappings.FromAllInterfaces,
        getLifetimeManager: WithLifetime.ContainerControlled );

    // viewの登録
    _container.RegisterTypes(
        AllClasses.FromAssemblies( typeof( MonitorModule ).Assembly )
            .Where( x => x.Namespace.EndsWith( ".Views" ) ),
        getFromTypes: _ => new[] { typeof( object ) },
        getName: WithName.TypeName );
    ```
