   M S B A M L   `   `   `  ����C  ?HCRM.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:HCRM.App.Views.ConvertersHCRM.App.Views.Converters  5	      p lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls 5
      M+clr-namespace:HCRM.App.Views.CustomControlsHCRM.App.Views.CustomControls  5      +    %HCRM.App.Pages.Employees.ListEmployee   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI  5      X TXceed.Wpf.Toolkit, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      0cv'clr-namespace:HCRM.App.Views.Converters  5	      cControlsTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit  5
      ?customControl+clr-namespace:HCRM.App.Views.CustomControls  5      $
��1500��5      .��5      �    ContentRoot#��[  6   .+�5   
   %  Xceed.Wpf.Toolkit.BusyIndicator  -   5        $��busyIndicator��5          IsBusy  62   �� *IsBusy+   BusyContent 5   
   �� 5      .+�5      �� $��Center=�6   Please wait...6I   5      ��5   
   �� 5      .��5      �� -   5        $��rootForm��5      .+�5      ��  �� Orientation$ 
Horizontal=�6   $��20q�66   .+�5      �� $��
Từ khóa��6    -  'System.Windows.Controls.AutoCompleteBox  5      $	��250��6/   $
��10 0q�6;      ValueMemberPath$
 Name��5   /      IsTextCompletionEnabled .    MinimumPrefixLength$ 2��5!   /      MinimumPopulateDelay$	 300��5"   /   $��Center=�5#   /      ItemsSource 5   I   �� *	Employees+   
ItemFilter 5   /   �� *EmployeeFilter+	   SelectedItem	 5    /   �� *CurrentEmployee+
 �� Mode$
 OneWayToSource=�   ItemTemplate 5%      �� 5&      .R�5'   "   �� .+�5(   &   �� ��60   �� *Name+�� 5)   &   ��60   �� *Email+5*   #   5+      50      �� 52      $��Tạo mới��6   $
��Left=�6V   ��6/   �� *NewEmployeeCommand+6V   �� 53      $��Xuất báo cáo��6%   $	��150��6<   ��6H   �� *ExportCommand+54      � 55      $
��Left=�6    � Orientation$ 
Horizontal=�67   .+�56      �� $��0��6!    � DataContext 61   �� *PagingViewModel+.+�57   "   &   System.Windows.Controls.DataGrid     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 150 6+   $
��Left=�6=      AutoGenerateColumns .     	RowHeight$ 50Q�58         CanUserAddRows .     CanUserDeleteRows .  $��Center=�6[   ��57   t   �� *
LstDisplay+ �� SelectedItem 6�   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" >� �� Path$! DataContext.CurrentEmployee� J� InputBindings 59      �� 5:   "   
 �� Key$ Delete��6-    �� Command 6:   �� *DeletePersonCommand+   Columns 5=      4  .System.Windows.Controls.DataGridTemplateColumn  5>   "   ,  &System.Windows.Controls.DataGridColumn   Header$ Hình ảnh��69      CellTemplate 5?   &   �� 5@   *   .R�5A   .   �� $��50��6N   ��64   �� *Avatar+6N   5B   +   5D   #   0  *System.Windows.Controls.DataGridTextColumn  5E   "   $ 	Họ tên��65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *Name+  5F   "   $ Chức vụ��65    6F   �� *
Position+  5G   "   $ Công việc��65    6H   �� *JobDescription+5J      5	   /HCRM.App.Views.CustomControls.PaginDataGridView	  5K      $
��Auto��6:   $��Center=�6G   5L      �� 5M      $
��Left=�6!   $��1��6<   .+�5N      �� $��20q�6J   $	��150��6V   ��6    �� *CurrentEmployee.Avatar+6V   5O      5P      �� 5S       6   �� *CurrentEmployee+.+�5U      �� $ 
Horizontal=�6!   .+�5V      �� $��Thông tin nhân viên��6$     Heading2#��[ 6@   $��10q�6b   �� 5W      $
��Lưu��6!     NormalButtonStyle#��[ 6/   $
��Left=�6z   $
��10 0q�6�   ��6Z   �� *SaveCommand+6�   �� 5X      $
��Xóa��6!     RedButtonStyle#��[ 6/   $
��Left=�6y   $
��10 0q�6�   ��6W   �� *RemoveCommand+6�   5Y      � 5Z        	WrapInfos#��[ 6    .+�5[      �� .+�5\      �� $��	Họ tên��6(   )
  #Xceed.Wpf.Toolkit.AutoSelectTextBox
  5]      ��65   �� *Name+5^      �� 5_      .+�5`      �� $
��CMND��6(   
  5a      ��65   �� *IdCardNumber+5b      �� 5c      .+�5d      �� $��Sô điện thoại��6(   
  5e      ��65   �� *PhoneNumber+5f      �� 5g      .+�5h      �� $��Email��6(   
  5i      ��65   �� *Email+5j      �� 5k      .+�5l      �� $��Chức vụ��6(   
  5m      ��65   �� *
Position+5n      �� 5o      .+�5p      �� $��Công việc��6(   
  5q      $��60��65    �� TextWrapping$
 Wrap=�6D   ��6X   �� *JobDescription+5r      �� 5s      .+�5t      �� $��Địa chỉ��6(   
  5u      ��65   ��   �� ElementName$  rootForm��$' !DataContext.CurrentAddress.Street�5v      �� 5w      .+�5x      �� $��Tỉnh thành��6(   
  5y      ��65   �� $  rootForm��$% DataContext.CurrentAddress.City�5z      �� 5{      $
��auto��6%   .+�5|      �� $	��480��6P    6)   �� *AvatarFileDlg+.+�5}   "   �� $��Hình ảnh��6,   
  5~   "   ! �� 
IsReadOnly! . $��85��6K   ��6V   �� *
FileName+�� 5   "   $��Browse��6)   $��30��6:   ��6I   �� *OpenCommand+5�      5�      �� 5�      $	��480��6L    6%   �� *ProfileFileDlg+.+�5�      �� $��	Sơ yếu��6(   
  5�   &   ! . $	��130��6O   ��6[   �� *
FileName+�� 5�      $��Browse��6%   $��30��66   ��6E   �� *OpenCommand+5�      �� 5�      .+�5�      �� $��0q�6(   �� 5�   "   -   5        ��5�   X   �� *ProfileFilePath+" �� TextDecorations" 6�   Z� .�6�   .�5�   &   �� $��	Open File��60   y�6A   �� *ProfileFilePath+# �� 	Converter# 6   0HCRM.App.Views.Converters.IsEmptyStringConverter  6�   5�      5�      5�      5�      5�      5�      5�      5�      5�      