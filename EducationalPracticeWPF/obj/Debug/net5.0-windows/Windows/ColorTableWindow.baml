   M S B A M L   `   `   `  ����  EducationalPracticeWPF5    /EducationalPracticeWPF.Windows.ColorTableWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   -   5          � Title$  
Цвета��5   	   $	��600��5   	   $	��350��5	   	    � 	Resources 5       �� 
TargetType �� Property �� Value��%^  '��       '�� �     �� 5   
   " ��6   .�5      ��  � ��$	 200��6&   �� 5       � ��$ 30��6'   �� 5       � ��$ 16(�6)   �� 5       � ��$ Bottom=�69   5      �� 5   
   " ��6   .�5      ��  � ��$	 100��6&   �� 5       � ��$ 30��6'   �� 5       � ��$ 16(�6)   5      5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $
��0.5* �6   �� 5      $��5* �6   �� 5       $
��0.5* �6    � ColumnDefinitions 5#   
   �� 5$      �� 5%      �� 5&      .+�5)   
   � $��0��5*      $��0��5+      $��3��5,      $��10q�5-       5.      �� 5/      �� 50      �� 51      .+�54      �� -   5         ��Name$ SearchTB��56      $��0��55      $	��100��57      $��
Найти��58      �� 5:      -   5        $��1��5;      $��
Найти��5<      5=      �� 5?      -   5        $��2��5@      $��Очистить��5A      5B      5C      �� 5E   
   -   5        $ ColorNamingTB��5I      $��1��5F      $��3��5G      $��0��5H      $	��250��5J      $��Bottom=�5K       �� 	MaxLength$	 100��5L      $��Наименование��5M      &   System.Windows.Controls.DataGrid  5O   
   -   5        	  Name$	 ColorDataGrid��5S      $��2��5P      $��3��5Q      $��0��5R      $��5q�5T      
   AutoGenerateColumns$
 False��5V         CanUserAddRows$ False��5W         CanUserDeleteRows$ False��5X         
IsReadOnly$
 True��5Y         CanUserReorderColumns$ False��5Z      ��5U      ��    Columns 5]      0  *System.Windows.Controls.DataGridTextColumn  5^      ,  &System.Windows.Controls.DataGridColumn   Header$ Цвет��6@      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Naming+6N   5`      �� 5b   
   -   5        $��3��5c      $��0��5d      $��Добавить��5e      5f      �� 5h   
   -   5        $��3��5i      $��1��5j      $��Сохранить��5k      5l      �� 5n   
   -	   5        $��3��5o      $��2��5p      $��Удалить��5q      5r      5s      5t      