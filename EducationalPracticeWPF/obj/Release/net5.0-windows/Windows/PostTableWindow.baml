   M S B A M L   `   `   `  ����   EducationalPracticeWPF4    .EducationalPracticeWPF.Windows.PostTableWindow   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -     � Title$  Должности��$	��600��$	��350�� � 	Resources  �� 
TargetType �� Property �� Value��%�   '��       '�� �     �� " ��.���  � ��$	 200����  � ��$ 30����  � ��$ 16(���  � ��$ Bottom=���  �@��	MaxLength$	 100���� " ��.���  � ��$	 100����  � ��$ 30����  � ��$ 16(�.���  � RowDefinitions �� �� �� $��5* ��� $
��0.5* � � ColumnDefinitions �� �� �� .+�� $��0��$��0��$��3��$��10q� �� �� �� .+��� -    ��Name$ SearchTB��$��0��$	��100��$��
Найти���� -   $��1��$��
Найти���� -   $��2��$��Очистить��� $��1��$��0��$��3��
������� �� �� .+��� -   $ 
PostNaming��$��0��$��Наименование���� -   $ 
PostSalary��$��1��$��
Оклад��&   System.Windows.Controls.DataGrid  -     Name$ PostDataGrid��$��2��$��3��$��0��$��5q�	   
IsReadOnly$
	 True��
   CanUserAddRows$
 False��   CanUserDeleteRows$ False��   AutoGenerateColumns$ False��   SelectionMode$ Single=�   SelectionUnit$ FullRow=�����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Наименование��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Naming+  $ 
Оклад��$
 0.4*  �� *Salary+�� -   $��3��$��0��$��Добавить���� -	   $��3��$��1��$��Сохранить���� -
   $��3��$��2��$��Удалить��