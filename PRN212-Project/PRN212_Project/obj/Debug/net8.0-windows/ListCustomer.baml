   M S B A M L   `   `   `  ����I  EAssignmentPRN1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AssignmentPRN1AssignmentPRN1  5      !    AssignmentPRN1.ListCustomer   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:AssignmentPRN1     5      .��5	      � $��10,45,10,99q�6     � ColumnDefinitions  5   
   �� 5      $��4* �6   �� 5      $��2* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��
dvgDisplay��5   #   $��0��6      AutoGenerateColumns$ False��65      CanUserAddRows$ False��6Q   $��	0,0,0,-73q�6h      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$ ID��6/   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *
CustomerId+ �� Mode$ OneWay=�  5      $ * 6%   $ FullName��6/    6A   �� *CustomerFullName+$ OneWay=�  5      $ * 6%   $ 	Telephone��6/    6B   �� *	Telephone+$ OneWay=�  5      $ * 6%   $ Email��6/    6>   �� *EmailAddress+$ OneWay=�  5      $ * 6%   $	 DOB��6/    6<   �� *CustomerBirthday+$ OneWay=�  5      $ * 6%   $ Status��6/    6?   �� *CustomerStatus+$ OneWay=�  5      $ * 6%   $ Password��6/    6A   �� *
Password+$ OneWay=�5      �� 5   
   $��1��6   $��	0,0,0,-73q�6%   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��5q�62   .+�5      �� $��50��6   .��6#   Id6'   �� 5      -   5        $��txtId��5   ,   	 �� 
IsReadOnly$
	 True��6   $	��200��69   ��6E   �� 
 �� ElementName$
 
dvgDisplay�� �� Path$ SelectedItem.CustomerId�$ OneWay=�5      �� 5       $ 
Horizontal=�6   $��5q�62   .+�5!      �� $��50��6   .��6#   Name6)   �� 5"      -   5        $��txtName��5"   ,   $
	 true��6   $	��200��6;   ��6G   �� $
 
dvgDisplay��$# SelectedItem.CustomerFullName�$ OneWay=�5#      �� 5$      $ 
Horizontal=�6   $��5q�62   .+�5%      �� $��50��6   .��6#   Phone6*   �� 5&      -   5        $��txtPhone��5&   ,   $
	 true��6   $	��200��6<   ��6H   �� $
 
dvgDisplay��$ SelectedItem.Telephone�$ OneWay=�5'      �� 5(      $ 
Horizontal=�6   $��5q�62   .+�5)      �� $��50��6   .��6#   Email6*   �� 5*      -   5        $��txtEmail��5*   ,   $
	 true��6   $	��200��6<   ��6H   �� $
 
dvgDisplay��$ SelectedItem.EmailAddress�$ OneWay=�5+      �� 5,      $ 
Horizontal=�6   $��5q�62   .+�5-      �� $��50��6   .��6#   DOB6(   �� 5.      -   5        $��dpkDob��5.   ,   $
	 true��6   $	��200��6:   ��6F   �� $
 
dvgDisplay��$# SelectedItem.CustomerBirthday�$ OneWay=�5/      �� 50      $ 
Horizontal=�6   $��5q�62   .+�51      �� $��50��6   .��6#   Status6+   �� 52      -   5        $��	txtStatus��52      $	��200��6-   ��69   �� $
 
dvgDisplay��$! SelectedItem.CustomerStatus�$ OneWay=�53      �� 54      $ 
Horizontal=�6   $��5q�62   .+�55      �� $��50��6   .��6#   Pass6)   �� 56      -   5        $��txtPassword��56   ,   $
	 true��6   $	��200��6?   ��6K   �� $
 
dvgDisplay��$ SelectedItem.Password�$ OneWay=�57      �� 58      $ 
Horizontal=�6   $��Center=�62   $��5q�6O   .+�5:      �� -	   5        $��Update��5:      $��5q�6*   65   �� 5;      -
   5        $��Delete��5;      $��5q�6*   65   5<      5=      5>      5A      