   M S B A M L   `   `   `  ����p  lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls  5      C ?HCRM.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:HCRM.App.Views.ConvertersHCRM.App.Views.Converters 5	      M+clr-namespace:HCRM.App.Views.CustomControlsHCRM.App.Views.CustomControls 5
      +   %HCRM.App.Pages.Products.ImportProduct   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI  5      cControlsTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit  5      X TXceed.Wpf.Toolkit, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      7	converter'clr-namespace:HCRM.App.Views.Converters  5	      ?customControl+clr-namespace:HCRM.App.Views.CustomControls  5
      .��5      � .+�5   
   %  Xceed.Wpf.Toolkit.BusyIndicator  -   5        $��busyIndicator��5          IsBusy  62   �� *IsBusy+   BusyContent 5      �� 5      .+�5      �� $��Center=�6    Please wait...6M   5      ��5      �� 5      .��5      �� -   5        $��rootForm��5   !   $	��500��61   .+�5      ��  �� Orientation$ 
Horizontal=�6%   $��20q�6>   .+�5      �� $��Tìm kiếm��6(      Heading2#��[  68   -   'System.Windows.Controls.AutoCompleteBox  5      $
��10 0q�67      ValueMemberPath$ Title��5   /      IsTextCompletionEnabled .    MinimumPrefixLength$ 1��5   /      MinimumPopulateDelay$	 100��5    /   $��Center=�5!   /   $	��200��5"   /      ItemsSource 5   E   �� *
Products+   
ItemFilter 5   /   �� *ProductFilter+	   SelectedItem	 5   /   �� *CurrentItem+
 �� Mode$
 OneWayToSource=�   ItemTemplate 5$   "   �� 5%   &   .R�5&   *   �� .+�5'   .   �� ��68   �� *Title+�� 5(   .   ��68   �� *
Material+5)   +   5*   '   5,      �� 5-      $��Tạo mới��6%   $
��Left=�6]   ��67   �� *NewProductCommand+6]   5.      � 5/      $
��Left=�6$    � Orientation$ 
Horizontal=�6?   .+�50      ��  � DataContext 6)   �� *PagingDataGrid+.+�51   "   &   System.Windows.Controls.DataGrid     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 150 6+      AutoGenerateColumns .     	RowHeight$ 50Q�53   +      CanUserAddRows .     CanUserDeleteRows .  $��Center=�54   +   $��Center=�55   +   $	��300��56   +   ��51   Y   �� *
LstDisplay+ �� SelectedItem 52   +   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" >� �� Path$! DataContext.SelectedProduct�   Columns 5;   &   0  *System.Windows.Controls.DataGridTextColumn  5<   *   ,  &System.Windows.Controls.DataGridColumn   Header$
 Tên��6=   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6J   �� *Title+4  .System.Windows.Controls.DataGridTemplateColumn  5=   *   $ Hình ảnh��6A      CellTemplate 5>   .   �� 5?   2   .R�5@   6   �� $��50��6U   ��6<   �� *Image+6U   5A   3   5C   +     5D   *   $ 	Tồn kho��6=    6N   �� *TotalRemain+  5E   *   $ 	Đã bán��6=    6M   �� *
TotalSaled+5H   #   5	  /HCRM.App.Views.CustomControls.PaginDataGridView	  5I   "   $
��Auto��6B   $��Center=�6P   5J      �� 5K      $	��500��6P    6)   �� *CurrentDetails+.+�5L   "   �� $��
Chi tiết��6,   #��[  6=   $
��0 20q�6_   �� 5N   "   $ 
Horizontal=�6-   .+�5O   &   �� $��Số lượng��60   $
��Bold"�6@   $��Center=�6R   $
��10 0q�6n   )
  #Xceed.Wpf.Toolkit.AutoSelectTextBox
  5P   &   $��50��6|   ��6=   �� *
Quantity+ �� UpdateSourceTrigger$ PropertyChanged=�.��6�    J� InputBindings 5Q   *   �� 5R   .   
 �� Key$ Return��69    �� Command 5S   1   ��   �� ElementName$  rootForm��$" DataContext.AddToCartCommand�.��5U   A   5V   '   �� 5W   &   $��Giảm��60   $
��Bold"�6<   $��Center=�6N   $
��10 0q�6j   
  5X   &   $��50��6�   ��6=   �� *StrReducePrice+$ PropertyChanged=�.��6�    5Y   *   �� 5Z   .   $ Return��69    5[   1   �� $  rootForm��$" DataContext.AddToCartCommand�.��5]   A   5^   '   �� 5`   &   $ 
Horizontal=�61   .+�5a   *   �� $��Nhập��61     NormalButtonStyle#��[ 6@   $
��Left=�6�   $
��10 0q�6�   ��6k   �� $  rootForm��$" DataContext.AddToCartCommand�6�   �� 5b   *   $
��Xóa��61     RedButtonStyle#��[ 6?   $
��Left=�6�   $
��10 0q�6�   ��6g   �� $  rootForm��$ DataContext.RemoveCommand�6�   5c   '   5d   #   � 5e   "     	WrapInfos#��[ 6,   $ 
Horizontal=�6o    6O   �� *	Product+.+�5f   &   �� $
��Left=�61   $	��100��6L   .+�5g   *   �� $��80��6   $��10q�6�   ��60   �� $  rootForm��$' !DataContext.SelectedProduct.Image�6�   5h   '   � 5i   &   .+�5j   &   �� .+�5k   *   �� $��Mã sản phẩm��64   
  5l   *   ! �� 
IsReadOnly! . ��6S   �� *Code+5m   '   �� 5o   &   .+�5p   *   �� $��Tên sản phẩm��64   
  5q   *   ! . ��6S   �� *Title+5r   '   �� 5s   &   .+�5t   *   �� $
��Giá��64   
  5u   *   ! . ��6T   �� *StrNormalPrice+5v   '   �� 5w   &   .+�5x   *   �� $��	Tồn kho��64   $��Center=�6C   
  5y   *   ! . ��6S   �� *TotalRemain+5z   '   5{   '   5|   #   5~      5      � 5�      #��[ 6$   .+�5�      �� .+�5�   "   �� $��Nhân viên��6,     5�   "   $
 Name��5�   /    . $ 1��5�   /   $	 100��5�   /   $��Center=�5�   /    5�   ;   �� *	Employees+ 5�   /   �� *EmployeeFilter+	 5�   /   �� *SelectedEmployee+$
 OneWayToSource=� 5�   &   �� 5�   *   .R�5�   .   �� .+�5�   2   �� ��6<   �� *Name+�� 5�   2   ��6<   �� *PhoneNumber+5�   /   5�   +   5�   #   5�      �� 5�      .+�5�   "   �� $��Khách hàng��6,     5�   "   $
 Name��5�   /    . $ 1��5�   /   $	 100��5�   /   $��Center=�5�   /    5�   ;   �� *	Customers+ 5�   /   �� *CustomerFilter+	 5�   /   �� *SelectedCustomer+$
 OneWayToSource=� 5�   &   �� 5�   *   .R�5�   .   �� .+�5�   2   �� ��6<   �� *Name+�� 5�   2   ��6<   �� *PhoneNumber+5�   /   5�   +   5�   #   5�      5�      �� 5�       6%   �� *CurrentReceipt+.+�5�      � #��[ 6(   $
��Left=�6K   $ 
Horizontal=�6f   .+�5�   "     -   5        $��	dgDetails��5�   +   $��0��6<    .   .   .  ��5�   '   �� $  rootForm��$# DataContext.LstDisplayDetails� 5�   +   �� $  rootForm��$  DataContext.CurrentDetails� 5�   "   �� 5�   &   $ Delete��61    6>   �� *RemoveCommand+ 5�   "     5�   &   $ 	Mã hàng��69    6J   �� *Product.Code+  5�   &   $ Tiêu đề��69    6J   �� *Product.Title+  5�   &   $ Số lượng��69    6K   �� *
Quantity+  5�   &   $ 
Đơn giá��69    6J   �� *StrUnitPrice+  5�   &   $ Giảm��69    6G   �� *StrReducePrice+5�      �� 5�   "   $ Vertical=�6-   .+�5�   &   �� .+�5�   &   �� $��4��61   $��0��6A   $��Tổng cộng��6N   �� 5�   &   $��5��60   $��0��6@   $��Right=�6M   ��6i   �� *StrTotalAmount+5�   '   �� 5�   &   .+�5�   &   �� $��4��61   $��1��6A   $��Giảm giá ��6N   �� 5�   &   $��5��61   $��1��6A   $��Right=�6N   ��6j   �� *StrTotalReduce+5�   '   �� 5�   &   .+�5�   &   �� $��4��61   $��2��6A   $��Còn lại ��6N   �� 5�   &   $��5��61   $��2��6A   $��Right=�6N   ��6j   �� *StrTotalRemain+5�   '   �� 5�   &   .+�5�   &   �� $��4��61   $��3��6A   $��Thanh toán��6N   �� 5�   &   $��5��6.   $��3��6>   $��Right=�6K   ��6g   �� *StrTotalPaid+$ PropertyChanged=�5�   '   5�   #   5�      � 5�      #��[ 6(   .+�5�   &   �� .+�5�   *   �� $��0��64   $��0��6D   $��Khách hàng��6R   $��Center=�6d   $��5q�6   �� 5�   *   $��1��62   $��0��6B   $��5q�6j   $	��150��6u   ��6O   �� *	OrderName+6u   5�   '   �� 5�   &   .+�5�   *   �� $��0��64   $��1��6D   $��Địa chỉ��6R   $��Center=�6a   $��5q�6|   �� 5�   *   $��1��62   $��1��6?   $��5q�6n   $	��150��6y   ��6P   �� *OrderAddress+6y   5�   '   �� 5�   &   .+�5�   *   �� $��0��64   $��2��6D   $��Điện thoại��6R   $��Center=�6d   $��5q�6   �� 5�   *   $��2��62   $��1��6?   $��5q�6l   $	��150��6w   ��6P   �� *
OrderPhone+6w   5�   '   �� 5�   &   .+�5�   *   �� $��3��64   $��0��6A   $��
Giao hàng��6R   $��Center=�6c   $��5q�6~   �� 5�   &   $��3��6/   $��1��6<   $��5q�6o   $	��150��6z   " d� 	IsChecked" 6L   �� *IsDeliveried+6z   5�   '   5�   #   5�      �� 5�      $��Lưu hóa đơn��6!   $	��150��6n   $
��Left=�6z   $
��20 0q�6�   ��67   �� *$"CurrentReceipt.PrintPreviewCommand+6�   5�      5�      5�      5�      5�      