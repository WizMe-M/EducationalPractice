   M S B A M L   `   `   `  ����  EducationalPracticeWPF=    7EducationalPracticeWPF.Windows.PaymentMethodTableWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   -   5          � Title$!  Способы оплаты��5   	   $	��600��5   	   $	��350��5	   	    � 	Resources 5       �� 
TargetType �� Property �� Value��%�  '��       '�� �     �� 5   
   " ��6   .�5      ��  � ��$	 200��6&   �� 5       � ��$ 30��6'   �� 5       � ��$ 16(�6)   �� 5       �@��	MaxLength$	 100��6*   �� 5       � ��$ Bottom=�69   5      �� 5   
   " ��6   .�5      ��  � ��$	 100��6&   �� 5       � ��$ 30��6'   �� 5       � ��$ 16(�6)   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��0.5* �6   �� 5       $��5* �6   �� 5!      $
��0.5* �6    � ColumnDefinitions 5$   
   �� 5%      �� 5&      �� 5'      .+�5*   
   � $��0��5+      $��0��5,      $��3��5-      $��10q�5.       5/      �� 50      �� 51      �� 52      .+�55      �� -   5         ��Name$ SearchTB��57      $��0��56      $	��100��58      $��
Найти��59      �� 5;      -   5        $��1��5<      $��
Найти��5=      5>      �� 5@      -   5        $��2��5A      $��Очистить��5B      5C      5D      �� 5F   
   -   5        $ NamingTB��5J      $��1��5G      $��3��5H      $��0��5I      $	��250��5K      $��Наименование��5L      &   System.Windows.Controls.DataGrid  5N   
   -   5          Name$ PaymentMethodDataGrid��5R      $��2��5O      $��3��5P      $��0��5Q      $��5q�5S      	   AutoGenerateColumns$	 False��5U      
   CanUserAddRows$
 False��5V         CanUserDeleteRows$ False��5W         
IsReadOnly$
 True��5X         CanUserReorderColumns$ False��5Y      ��5T      ��    Columns 5\      0  *System.Windows.Controls.DataGridTextColumn  5]      ,  &System.Windows.Controls.DataGridColumn   Header$ Способ оплаты��6@      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Naming+6W   5_      �� 5a   
   -   5        $��3��5b      $��0��5c      $��Добавить��5d      5e      �� 5g   
   -   5        $��3��5h      $��1��5i      $��Сохранить��5j      5k      �� 5m   
   -	   5        $��3��5n      $��2��5o      $��Удалить��5p      5q      5r      5s      