   M S B A M L   `   `   `  ����   EducationalPracticeWPF8    2EducationalPracticeWPF.Windows.EmployeeTableWindow   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -     � Title$  Сотрудники��$	��650��$
��1100�� � 	Resources  �� 
TargetType �� Property �� Value��%v  '��       '�� �     '�� �     �� " ��.���  � ��$	 180����  � ��$ 40����  � ��$ 20(���  � ��$ Center=���  � ��$ Bottom=��� " ��.���  � ��$	 120����  � ��$ 30����  � ��$ 16(��� " ��.���  � ��$	 280����  � ��$ 50����  � ��$ 18(���  � ��$ Center=���  � ��$ Center=�.���  � ColumnDefinitions �� $��3* ��� $��2* �.+�&   System.Windows.Controls.DataGrid  -     Name$ EmployeeDataGrid��$��0��$��0��   
IsReadOnly$
 True��   CanUserAddRows$ False��	   CanUserDeleteRows$	 False��
   AutoGenerateColumns$
 False��   SelectionMode$ Single=�   SelectionUnit$ FullRow=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Имя��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.8* 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	FirstName+  $ Фамилия��$ *  �� *
LastName+  $ Отчество��$ *  �� *
MiddleName+  $ 
Серия��$
 0.5*  �� *PassportSeries+  $ 
Номер��$
 0.6*  �� *PassportNumber+  $ ИНН��$
 0.8*  �� *Inn+  $ Должность��$
 1.2*  �� *Post.Naming+� $��0��$��1��
������� � RowDefinitions �� �� �� �� �� �� �� ��  �� �� �� .+�� $��0��$��0��$��3��$��10q� �� �� �� .+��� -    ��Name$ SearchTB��$��0��$	��100��$��
Найти���� -   $��1��$��
Найти���� -   $��2��$��Очистить���� -   $ 
LastNameTB��$��1��$��0��$��3���� -   $ FirstNameTB��$��2��$��0��$��3���� -   $ MiddleNameTB��$��3��$��0��$��3���� -	   $ SeriesPassportTB��$��4��$��0��$��2��$	��100���� -
   $ NumberPasswordTB��$��4��$��1��$��2��$	��100���� -   $ InnTB��$��5��$��0��$��3���� -    ��Name$ PostsCB��$��6��$��0��$��3���� -   $��7��$��0��$��Добавить���� -   $��7��$��1��$��Сохранить���� -   $��7��$��2��$��Удалить��