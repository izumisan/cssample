# README

WPFアニメーションのサンプル

# overview

- AnimationSample
    - 単純なアニメーションのサンプル
- AnimationSample2


# 覚書

## アニメーションクラス

- DoubleAnimation
- ColorAnimation
- PointAnimation

## アニメーション制御（ストリーボード制御）

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
