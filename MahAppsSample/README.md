# MahApps.Metro

MahApps.Metroのサンプル

# overview

- MetroWindow
    - MetroWindowのウィンドウ設定サンプル
- HamburgerMenuDefault
    - HamburberMenuのサンプル
- HamburgerMenuCreatorsUpdate
    - HamburgerMenuCreatorsUpdateのサンプル

# 覚書

# 利用頻度が高いプロパティ

- MetroWindow
    - `TitleCaps`
        - `False`にすることで、ウィンドウタイトルが自動で大文字化されなくなる
    - `GlowBrush`
        - ウィンドウ枠がぼやける
    - `EnableDWMDropShadow`
        - ウィンドウ枠に影の有無
        - `True`で影ができるが、本設定は`GlowBrush`や`BorderBrush`より優先されるっぽい
    - `WindowTransitionsEnabled`
        - 起動時の画面スライドアニメーションの有無
