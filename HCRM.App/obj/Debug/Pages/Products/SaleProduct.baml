   M S B A M L   `   `   `  ����p  lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls  5      C ?HCRM.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:HCRM.App.Views.ConvertersHCRM.App.Views.Converters 5	      M+clr-namespace:HCRM.App.Views.CustomControlsHCRM.App.Views.CustomControls 5
      )   #HCRM.App.Pages.Products.SaleProduct   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI  5      cControlsTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit  5      X TXceed.Wpf.Toolkit, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      7	converter'clr-namespace:HCRM.App.Views.Converters  5	      ?customControl+clr-namespace:HCRM.App.Views.CustomControls  5
      .��5      � .+�5   
   %  Xceed.Wpf.Toolkit.BusyIndicator  -   5        $��busyIndicator��5          IsBusy  62   �� *IsBusy+   BusyContent 5      �� 5      .+�5      �� $��Center=�6    Please wait...6M   5      ��5      �� 5      .��5      �� -   5        $��rootForm��5   !   $	��500��61   .+�5      ��  �� Orientation$ 
Horizontal=�6%   $	��0 5q�6>    � DataContext 6L   ��  �� ElementName$ rootForm�� �� Path$ DataContext�.+�5      �� $��
Từ khóa��6(   $��20q�67   $	��110��6C   -   'System.Windows.Controls.AutoCompleteBox  5         ValueMemberPath$
 Name��5   1   $	��150��6H      IsTextCompletionEnabled .    MinimumPrefixLength$ 0��5    1   	   MinimumPopulateDelay$	 10��5!   1   $��Center=�5"   1   
   ItemsSource
 5   7   �� *
Products+   
ItemFilter 5   1   �� *ProductFilter+   SelectedItem 5   1   �� *SelectedProduct+ �� Mode$ OneWayToSource=�   ItemTemplate 5$   "   �� 5%   &   .R�5&   *   �� $��3q�65   .+�5'   .   �� ��68   �� *Title+�� 5(   .   ��68   �� *
Material+5)   +   5*   '   5,      5-      � 5E      $
��Left=�6$   .+�5G      �� $
��5 10q�6(   $��SẢN PHẨM��66   $	��500��6H   .��5H   "   �� $ Vertical=�6-   .+�5I   "   ��  6-   �� *PagingDataGrid+.+�5J   &   &   System.Windows.Controls.DataGrid     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 110 6/      AutoGenerateColumns .     	RowHeight$ 50Q�5L   +      CanUserAddRows .     CanUserDeleteRows .  $��Center=�5M   +   $��Center=�5N   +   $	��300��5O   +   ��5J   ]   �� *
LstDisplay+ �� SelectedItem 5K   +   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" >�$! DataContext.SelectedProduct�   Columns 5T   *   0  *System.Windows.Controls.DataGridTextColumn  5U   .   ,  &System.Windows.Controls.DataGridColumn   Header$
 Tên��6A   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6N   �� *Title+4  .System.Windows.Controls.DataGridTemplateColumn  5V   .   $ Hình ảnh��6E      CellTemplate 5W   2   �� 5X   6   .R�5Y   :   �� $
��Left=�6@   $��50��6t   ��6[   �� *Image+6t   5Z   7   5\   /     5]   .   $ 	Tồn kho��6A    6R   �� *TotalRemain+  5^   .   $ 	Đã bán��6A    6Q   �� *
TotalSaled+5a   '   5	  /HCRM.App.Views.CustomControls.PaginDataGridView	  5b   &   $
��Auto��6F   $��Center=�6T   5c   #   �� 5d   "   $
��Left=�6-   $��10 20q�6H   $	��500��6~    6W   �� *CurrentDetails+.+�5e   &   �� $ 
Horizontal=�61   $��Center=�6J   .+�5f   *   �� $
��10 0q�61   $��30��6?   $��Xem sản phẩm��6K   ��6b   �� *Product.PreviewCommand+�� 5g   *   $��20q�6Q   $��50��6]   ��60   �� *Product.Image+6]   5h   +   �� 5i   &   $ 
Horizontal=�61   .+�5j   *   �� $��Số lượng��64   $
��Bold"�6D   $��Center=�6V   $
��10 0q�6r   )
  #Xceed.Wpf.Toolkit.AutoSelectTextBox
  5k   *   $��50��6�   ��6A   �� *
Quantity+ �� UpdateSourceTrigger$ PropertyChanged=�.��6�    J� InputBindings 5l   .   �� 5m   2   
 �� Key$ Return��6=    �� Command 5n   1   �� $ rootForm��$" DataContext.AddToCartCommand�.��5p   E   5q   +   �� 5r   *   $��Giảm��64   $
��Bold"�6@   $��Center=�6R   $
��10 0q�6n   
  5s   *   $��50��6�   ��6A   �� *StrReducePrice+$ PropertyChanged=�.��6�    5t   .   �� 5u   2   $ Return��6=    5v   1   �� $ rootForm��$" DataContext.AddToCartCommand�.��5x   E   5y   +   �� 5{   *   $ 
Horizontal=�65   .+�5|   .   �� $��Nhập��65      NormalButtonStyle#��[  6D   $
��Left=�6�   $
��10 0q�6�   ��6o   �� $ rootForm��$" DataContext.AddToCartCommand�6�   �� 5}   .   $
��Xóa��65     RedButtonStyle#��[ 6C   $
��Left=�6�   $
��10 0q�6�   ��6k   �� $ rootForm��$ DataContext.RemoveCommand�6�   5~   +   5   '   5�   #   5�      5�      �� 5�      $ Vertical=�6)    6A   �� *CurrentReceipt+.+�5�   "   �� $
��5 10q�6+   $��CHI TIẾT HÓA ĐƠN��6:   .��5�   "   �� .+�5�   &   �   	WrapInfos#��[ 60   $
��Left=�6S     � Orientation$  
Horizontal=�6n   .+�5�   *     -   5        $��	dgDetails��5�   3   $��0��6D    .  $ 90 6m    .   .  ��5�   '   �� $ rootForm��$# DataContext.LstDisplayDetails� 5�   +   �� $ rootForm��$  DataContext.CurrentDetails� 5�   .   �� 5�   2   $ Delete��6=    6J   �� *RemoveCommand+ 5�   .     5�   2   $ 	Mã hàng��6E    6V   �� *Product.Code+  5�   2   $ Tiêu đề��6E    6V   �� *Product.Title+  5�   2   $ SL��6E    6Q   �� *
Quantity+  5�   2   $ 
Đơn giá��6E    6V   �� *StrUnitPrice+  5�   2   $ Giảm��6E    6S   �� *StrReducePrice+5�   +   �� 5�   *   $ Vertical=�65   $	��250��6L   .+�5�   .   �� .+�5�   2   �� $
��Bold"�6<   $��Tổng cộng��6N   �� 5�   6   $��80��6>   ! �� TextAlignment$! Right=�6I   ��6_   �� *StrTotalAmount+5�   /   �� 5�   .   .+�5�   2   �� $
��Bold"�6<   $��Giảm giá ��6N   �� 5�   6   $��80��6>   $! Right=�6I   ��6_   �� *StrTotalReduce+5�   /   �� 5�   .   .+�5�   2   �� $
��Bold"�6<   $��Còn lại ��6N   �� 5�   6   $��80��6>   $! Right=�6I   ��6_   �� *StrTotalRemain+5�   /   �� 5�   .   .+�5�   2   �� $
��Bold"�6<   $��Thanh toán��6N   �� 5�   2   $! Right=�6:   $��80��6P   ��6[   �� *StrTotalPaid+$ PropertyChanged=�5�   /   5�   +   5�   '   5�   '   5�   #   �� 5�   "   $
��5 10q�6+   $��Thông tin khách hàng��69   $
��auto��6W   .��5�   &   �� $ Vertical=�61   .+�5�   *   �� $ 
Horizontal=�65   $	��0 5q�6N    6\   �� $ rootForm��$ DataContext�.+�5�   .   �� $��Khách hàng��68   $��5 5 2 5q�6J   $	��110��6[     5�   .   $
 Name��5�   1   $	��150��6H    . $ 1��5�   1   $	 10��5�   1   $��Center=�5�   1   
 5�   G   �� *	Customers+ 5�   1   �� *CustomerFilter+ 5�   1   �� *SelectedCustomer+$ OneWayToSource=� 5�   2   �� 5�   6   .R�5�   :   �� $��3q�6E   .+�5�   >   �� ��6H   �� *Name+�� 5�   >   ��6H   �� *PhoneNumber+5�   ;   5�   7   5�   /   5�   +   � 5�   *   $	��600��64   #��[ 6C   $
��Left=�6f   .+�5�   .   �� .+�5�   2   �� $��Người nhận��6<   $��Center=�6N   $��5q�6i   �� 5�   2   $��5q�6W   $	��150��6b   ��6:   �� *ReceiveName+6b   5�   /   �� 5�   .   .+�5�   2   �� $��Địa chỉ��6<   $��Center=�6K   $��5q�6f   �� 5�   2   $��5q�6Z   $	��150��6e   ��6:   �� *ReceiveAddress+6e   5�   /   �� 5�   .   .+�5�   2   �� $��Điện thoại��6<   $��Center=�6N   $��5q�6i   �� 5�   2   $��5q�6X   $	��150��6c   ��6:   �� *ReceivePhone+6c   5�   /   �� 5�   .   .+�5�   2   �� $��
Giao hàng��6<   $��Center=�6M   $��5q�6h   �� 5�   2   $��5q�6^   $	��150��6i   " d� 	IsChecked" 6;   �� *IsDeliveried+6i   5�   /   5�   +   5�   '   5�   #   �� 5�   "   $
��5 10q�6+   $��Phụ trách đơn hàng��69   .��5�   &   � $	��600��60   $
��Left=�6?   #��[ 6Z    6}   �� $ rootForm��$ DataContext�.+�5�   *   �� .+�5�   .   �� $��Nhân viên��68   $��5q�6I     5�   .   $��5q�5�   I   $
 Name��5�   5    . $ 1��5�   5   $	 10��5�   5   $��Center=�5�   5   
 5�   G   �� *	Employees+ 5�   5   �� *EmployeeFilter+ 5�   5   �� *SelectedEmployee+$ OneWayToSource=� 5�   2   �� 5�   6   .R�5�   :   �� $��3q�6F   .+�5�   >   �� ��6H   �� *Name+�� 5�   >   ��6H   �� *PhoneNumber+5�   ;   5�   7   5�   /   5�   +   5�   '   5�   #   �� 5�   "   $��Lưu hóa đơn��6)   $	��150��6g   $
��Left=�6s   $��10 20q�6�   ��6?   �� *PrintPreviewCommand+6�   5�      5�      5�      5�      5�      5�      5      