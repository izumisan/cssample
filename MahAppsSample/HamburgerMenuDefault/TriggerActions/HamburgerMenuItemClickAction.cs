using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Interactivity;
using MahApps.Metro.Controls;

namespace HamburgerMenuDefault.TriggerActions
{
    public class HamburgerMenuItemClickAction : TriggerAction<HamburgerMenu>
    {
        protected override void Invoke( object parameter )
        {
            if ( parameter is ItemClickEventArgs )
            {
                // 選択したメニューのコンテンツを設定する
                this.AssociatedObject.Content = ( parameter as ItemClickEventArgs ).ClickedItem;
                // メニューアイテム選択時にメニューパネルを閉じるようにする
                this.AssociatedObject.IsPaneOpen = false;
            }
        }
    }
}
