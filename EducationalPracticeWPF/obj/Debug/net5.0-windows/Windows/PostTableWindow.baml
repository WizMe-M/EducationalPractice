   M S B A M L   `   `   `  ����  EducationalPracticeWPF4    .EducationalPracticeWPF.Windows.PostTableWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   -   5          � Title$  Должности��5   	   $	��600��5   	   $	��350��5	   	    � 	Resources 5       �� 
TargetType �� Property �� Value��%�  '��       '�� �     �� 5   
   " ��6   .�5      ��  � ��$	 200��6&   �� 5       � ��$ 30��6'   �� 5       � ��$ 16(�6)   �� 5       � ��$ Bottom=�69   �� 5       �@��	MaxLength$	 100��6*   5      �� 5   
   " ��6   .�5      ��  � ��$	 100��6&   �� 5       � ��$ 30��6'   �� 5       � ��$ 16(�6)   5      5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      $��5* �6   �� 5       $
��0.5* �6    � ColumnDefinitions 5#   
   �� 5$      �� 5%      �� 5&      .+�5)   
   � $��0��5*      $��0��5+      $��3��5,      $��10q�5-       5.      �� 5/      �� 50      �� 51      .+�54      �� -   5         ��Name$ SearchTB��56      $��0��55      $	��100��57      $��
Найти��58      �� 5:      -   5        $��1��5;      $��
Найти��5<      5=      �� 5?      -   5        $��2��5@      $��Очистить��5A      5B      5C      � 5E   
   $��1��5F      $��0��5G      $��3��5H      
������� 5K      �� 5L      �� 5M      .+�5P      �� -   5        $ 
PostNaming��5R      $��0��5Q      $��Наименование��5S      �� 5U      -   5        $ 
PostSalary��5W      $��1��5V      $��
Оклад��5X      5Y      &   System.Windows.Controls.DataGrid  5[   
   -   5          Name$ PostDataGrid��5_      $��2��5\      $��3��5]      $��0��5^      $��5q�5`      	   
IsReadOnly$
	 True��5b      
   CanUserAddRows$
 False��5c         CanUserDeleteRows$ False��5d         AutoGenerateColumns$ False��5e         SelectionMode$ Single=�5f         SelectionUnit$ FullRow=�5g      ��5a      ��    Columns 5j      0  *System.Windows.Controls.DataGridTextColumn  5k      ,  &System.Windows.Controls.DataGridColumn   Header$ Наименование��6@      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Naming+6V     5l      $ 
Оклад��6@   $
 0.4* 6O    6%   �� *Salary+6O   5n      �� 5p   
   -   5        $��3��5q      $��0��5r      $��Добавить��5s      5t      �� 5v   
   -	   5        $��3��5w      $��1��5x      $��Сохранить��5y      5z      �� 5|   
   -
   5        $��3��5}      $��2��5~      $��Удалить��5      5�      5�      5�      