   M S B A M L   `   `   `  ����L  HHCRM.WarehouseApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:HCRM.WarehouseAppHCRM.WarehouseApp  5   	   A%clr-namespace:HCRM.WarehouseApp.ViewsHCRM.WarehouseApp.Views  5   	   Y1clr-namespace:HCRM.WarehouseApp.Views.OthersViews#HCRM.WarehouseApp.Views.OthersViews  5	   	   W0clr-namespace:HCRM.WarehouseApp.Views.Converters"HCRM.WarehouseApp.Views.Converters  5
   	   K*clr-namespace:HCRM.WarehouseApp.ViewModelsHCRM.WarehouseApp.ViewModels  5   	   o<clr-namespace:HCRM.WarehouseApp.ViewModels.ProductViewModels.HCRM.WarehouseApp.ViewModels.ProductViewModels  5   	   m;clr-namespace:HCRM.WarehouseApp.ViewModels.OthersViewModels-HCRM.WarehouseApp.ViewModels.OthersViewModels  5   	   [2clr-namespace:HCRM.WarehouseApp.Views.ProductViews$HCRM.WarehouseApp.Views.ProductViews  5   	   G CMaterialMenu, Version=0.0.4.5, Culture=neutral, PublicKeyToken=nullA0clr-namespace:MaterialMenu;assembly=MaterialMenuMaterialMenu 5   	   '    !HCRM.WarehouseApp.ApplicationView   5   	   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X TXceed.Wpf.Toolkit, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   +localclr-namespace:HCRM.WarehouseApp  5   	   1views%clr-namespace:HCRM.WarehouseApp.Views  5   	   CothersViews1clr-namespace:HCRM.WarehouseApp.Views.OthersViews  5	   	   @	converter0clr-namespace:HCRM.WarehouseApp.Views.Converters  5
   	   ;
viewModels*clr-namespace:HCRM.WarehouseApp.ViewModels  5   	   TproductViewModels<clr-namespace:HCRM.WarehouseApp.ViewModels.ProductViewModels  5   	   RothersViewModels;clr-namespace:HCRM.WarehouseApp.ViewModels.OthersViewModels  5   	   EproductViews2clr-namespace:HCRM.WarehouseApp.Views.ProductViews  5   	   CmaterialMenu0clr-namespace:MaterialMenu;assembly=MaterialMenu  5   	   -   5          � Title$  HCRM - Home��5   	   $	��600��6   $	��960��6*    � 
ResizeMode$ CanResizeWithGrip=�5   	    � ShowInTaskbar .  � SizeToContent$ Manual=�6=    � WindowStartupLocation$ CenterScreen=�6T    � WindowState$ 	Maximized=�5   	    � 	Resources 5      >  8HCRM.WarehouseApp.Views.Converters.NullableBoolConverter   booleanConverter �� 
TargetType �� Triggers	 P� Property
 P� Value �� Property  SelectedBackgroundBrush �� Value �� DataType0  *HCRM.WarehouseApp.ViewModels.HomeViewModel"   HCRM.WarehouseApp.Views.HomeI   CHCRM.WarehouseApp.ViewModels.ProductViewModels.ProductPageViewModel:   4HCRM.WarehouseApp.Views.ProductViews.ProductPageView1   +HCRM.WarehouseApp.ViewModels.LoginViewModel)   #HCRM.WarehouseApp.Views.LoginWindow4   .HCRM.WarehouseApp.ViewModels.SaleFormViewModel*	   $HCRM.WarehouseApp.Views.SaleFormViewI
   CHCRM.WarehouseApp.ViewModels.OthersViewModels.EmployeePageViewModel:   4HCRM.WarehouseApp.Views.OthersViews.EmployeePageViewI   CHCRM.WarehouseApp.ViewModels.OthersViewModels.CustomerPageViewModel:   4HCRM.WarehouseApp.Views.OthersViews.CustomerPageView��%l  &	        'm�      (�� �     5      *, +)(�� �     5#      *, +)(�� �     5'      *, +)(�� ,    5+      *, +)(�� ^    5/      *,
 +)(�� �    53      *, +)  5   
   6*   �� 5   
   " m�6    5      P� 5      	 �@J�	IsFocused
 . . �5      ��  � ��# �  63   5      5      �� 5   
   "  6   .R�5         5!      �� 5#   
   "  6   .R�5$        5%      �� 5'   
   "  6   .R�5(        5)      �� 5+   
   "  6   .R�5,      	  5-      �� 5/   
   " 
 6   .R�50        51      �� 53   
   "  6   .R�54        55      56      .��58      ]� .+�59   
   �� -   5         ��Name$ MainMenuBorder��59   5   $
��Left=�6   $
��auto��6'   $��0q�6M   $��2��6a   $	��300��6n   $��Center=�6z   ._�5:        MaterialMenu.SideMenu  -   5        $��MainMenu��5:   $      Theme$ Danger=�64      ButtonBackground �	#FF567DB1.��5;      �� $��Hidden=�6   $
��Auto=�6S     InputBackgroundBrush#���  6�   .��5<      ��  �� Orientation$ Vertical=�6!   .+�5=      �� ���#337AB5._�5>      � $��10q�6#   .+�5?   "   �� $	��100��6*   $��0q�67   
������ $��Center=�5@   !   $��Calibri)�6C   $��18(�6X   
�������$
��Bold"�5A   9   $
��Left=�6K   $��Center=�6f   .��6�   	Welcome6�   5B      5C      5U      5V      5W      5X      �� 5Y   
   -   5        $ 
MainScreen��5Y      $
��auto��6%   $��0q�63   $��3��6G   ._�5Z      � $y�Visible=�6    � RowDefinitions 5[      �� 5\      $	��120 �6$   �� 5]      $��* �6$   $	��330��6/   �� 5^      $	��120 �6$   .+�5a      �� $	��120��6   $��0��6'   $	��Top=�64   ._�5b      � $��10q�6   .+�5c      �� $	��100��6"   $��0q�6/   
������ $��Center=�5d   !   $��Calibri)�6C   $��32(�6X   $
��Bold"�5e   !   $
��Left=�63   $��Center=�6N   .��6i   Header Company Name6~   5f      5g      �� 5h      $��1��6   ._�5i      %  Xceed.Wpf.Toolkit.BusyIndicator  -   5        $��busyIndicator��5i   )      IsBusy 6>   �� *IsBusy+   BusyContent 5j      �� 5k      .+�5l   "   �� $��Center=�6,   Please wait...6Y   5n      ��5q      �� 5r      $��Hidden=�6+   $
��Auto=�6_   #���  6�   .��5s   "   �� 
�������.+�5t   &   �� ��65   �� *CurrentPageViewModel+5u   #   5v      5y      5z      �� 5{      $��2��6   $	��120��6&   $��Bottom=�65   ._�5|      � $��10q�6   .+�5}      �� $	��100��6"   $��0q�6/   
������ $��Center=�5~   !   $��Calibri)�6C   $��32(�6X   $
��Bold"�5   !   $
��Left=�63   $��Center=�6N   .��6i   Footer6q   5�      5�      5�      5�      5�      5�      