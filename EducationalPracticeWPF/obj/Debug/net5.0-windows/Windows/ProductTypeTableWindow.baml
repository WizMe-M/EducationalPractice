   M S B A M L   `   `   `  ����  EducationalPracticeWPF;    5EducationalPracticeWPF.Windows.ProductTypeTableWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   -   5          � Title$  Виды товаров��5   	   $	��600��5   	   $	��350��5	   	    � 	Resources 5       �� 
TargetType �� Property �� Value��%^  '��       '�� �     �� 5   
   " ��6   .�5      ��  � ��$	 200��6&   �� 5       � ��$ 40��6'   �� 5       � ��$ 20(�6)   �� 5       � ��$ Bottom=�69   5      �� 5   
   " ��6   .�5      ��  � ��$	 100��6&   �� 5       � ��$ 30��6'   �� 5       � ��$ 16(�6)   5      5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $
��0.5* �6   �� 5      $��5* �6   �� 5       $
��0.5* �6    � ColumnDefinitions 5#   
   �� 5$      �� 5%      �� 5&      .+�5)   
   � $��0��5*      $��0��5+      $��3��5,      $��10q�5-       5.      �� 5/      �� 50      �� 51      .+�54      �� -   5         ��Name$ SearchTB��56      $��0��55      $	��100��57      $��
Найти��58      �� 5:      -   5        $��1��5;      $��
Найти��5<      5=      �� 5?      -   5        $��2��5@      $��Очистить��5A      5B      5C      �� 5E   
   -   5        $ ProductTypeNamingTB��5I      $��1��5F      $��3��5G      $��0��5H      $��16(�5J      $	��250��5K      $��30��5L      $��Bottom=�5M       �� 	MaxLength$	 100��5N      $��Наименование��5O      &   System.Windows.Controls.DataGrid  5Q   
   -   5        	  Name$	 ProductTypeDataGrid��5U      $��2��5R      $��3��5S      $��0��5T      $��5q�5V      
   AutoGenerateColumns$
 False��5X         CanUserAddRows$ False��5Y         CanUserDeleteRows$ False��5Z         
IsReadOnly$
 True��5[         CanUserReorderColumns$ False��5\      ��5W      ��    Columns 5_      0  *System.Windows.Controls.DataGridTextColumn  5`      ,  &System.Windows.Controls.DataGridColumn   Header$4 .Наименование вида товара��6@      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6b   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Naming+6b   5b      �� 5d   
   -   5        $��3��5e      $��0��5f      $��Добавить��5g      5h      �� 5j   
   -   5        $��3��5k      $��1��5l      $��Сохранить��5m      5n      �� 5p   
   -	   5        $��3��5q      $��2��5r      $��Удалить��5s      5t      5u      5v      