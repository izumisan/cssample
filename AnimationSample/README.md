# README

WPFアニメーションのサンプル

# overview

- AnimationSample
    - 単純なアニメーションのサンプル
- AnimationSample2
    - 開始・停止等のアニメーション制御のサンプル
- KeyFrameAnimation
    - キーフレームアニメーションのサンプル

# 覚書

## 概要

1. ストリーボードを定義する
    - `Resources`又は`Style`に定義する
1. ストリーボード中にアニメーションを設定する
1. ストリーボードを開始する（`BeginStoryboard`）
    - `Storyboard`はトリガアクションなので、`Trigger`, `EventTrigger`等で開始させる

## アニメーションクラス

- DoubleAnimation
- ColorAnimation
- PointAnimation

## ストリーボード（アニメーション制御）

- BeginStoryboard
    - ストリーボードを開始する
- PauseStoryboard
    - ストリーボードを一時停止する
- ResumeStoryboad
    - 一時停止中のストーリーボードを再開する
- SetStoryboardSpeedRatio
    - ストーリーボードの速度（レート）を変更する
- SkipStoryboardToFill
    - 実行中のストーリーボードをスキップする
        - 終了後の状態になる？
    - `RepeatBehavior="Forever"`のストリーボードに適用すると例外となる
- StopStoryboard
    - ストリーボードを停止する
        - 開始前の状態に戻る？
- RemoveStoryboard
    - ストリーボードを削除する
        - （不明）


# リンク

- [アニメーションの概要](https://docs.microsoft.com/ja-jp/dotnet/framework/wpf/graphics-multimedia/animation-overview)
- [キー フレーム アニメーションの概要](https://docs.microsoft.com/ja-jp/dotnet/framework/wpf/graphics-multimedia/key-frame-animations-overview)
- [イージング関数](https://docs.microsoft.com/ja-jp/dotnet/framework/wpf/graphics-multimedia/easing-functions)
- [第10回　WPFの「入力イベントとアニメーション」を学ぼう (2/2)](https://www.atmarkit.co.jp/ait/articles/1103/01/news124_2.html)
