# Shared Memory

共有メモリのサンプル

# overview

- [C++] CppWriter
- [C++] CppReader
- [C++] CppShared
- [C#] CsWriter
- [C#] CsReader
- [C#] CsShared
- [C#] Benchmark
    - read/write時間の確認用プロジェクト

# 覚書

- マネージオブジェクト => バイト列データ

    ```cs
    int size = Marshal.SizeOf<Foo>();
    byte[] dest = new byte[size];
    IntPtr ptr = Marshal.AllocCoTaskMem( size );

    // マネージデータをアンマネージデータにマーシャリング
    Marshal.StructureToPtr<Foo>( src, ptr, false );
    // IntPtr(アンマネージポインタ)をバイト列データにコピー
    Marshal.Copy( ptr, dest, 0, size );

    Marshal.FreeCoTaskMem( ptr );
    ```

- バイト列データ => マネージオブジェクト

    ```cs
    int size = Marshal.SizeOf<Foo>();
    byte[] src = new byte[size];
    IntPtr ptr = Marshal.AllocCoTaskMem( size );

    // srcにデータを設定
    xxxxx;

    // バイト列データをIntPtr(アンマネージポインタ)にコピー
    Marshal.Copy( src, 0, ptr, size );
    // アンマネージデータをマネージデータにマーシャリング
    dest = Marshal.PtrToStructure<Foo>( ptr );

    Marshal.FreeCoTaskMem( ptr );
    ```

