   M S B A M L   `   `   `  ����   Management_System$    Management_System.Malfunctions   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .��� .+�&   System.Windows.Controls.DataGrid  -      Name$  datagrid��$y�Hidden=�$��1000px��$��Center=�$��Center=�   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * $	��Top=�   AutoGenerateColumns .     CanUserResizeColumns .  � DataContext ��  �� Source$
 list��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 
תיאור��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� 	 �� Path$	 description�
   ElementStyle
 �� .���  �� Property � �� �� Value$
 Wrap=���  �@��TextAlignment$ Center=�  $ 
תאריך�� �� $
	 date�
 �� .���  � ��$
 Wrap=���  �@��TextAlignment$ Center=�  $ סוג�� �� $
	 type�
 �� .���  � ��$
 Wrap=���  �@��TextAlignment$ Center=�  $ 
בניין�� �� $	 building�
 �� .���  � ��$
 Wrap=���  �@��TextAlignment$ Center=��� -    ��Name$ back_button��$��חזרה��$
��Left=�$��672,503,0,0q�$	��Top=�$��75���� -    ��Name$ closedMalslvDataBinding��$
��Left=�$��Right=�$	��306��$��5,64,0,0q�$	��Top=�$	��375������  �� 
TargetType" ��.���  � ��$	 Top=���  � ��$ Center=� �� View �� .P��� $��
תאריך�� �� Width$	 115�� �� DisplayMemberBinding �� *date+�� $��סוג��$	 125�� �� *type+�� $��
בניין��$	 125�� �� *
building+�� -   $ openMalslvDataBinding��$
��Left=�$��Right=�$	��306��$��
405,64,0,0q�$	��Top=�$	��375������ " ��.���  � ��$	 Top=���  � ��$ Center=� �� .P��� $��
תאריך��$	 115�� �� *date+�� $��סוג��$	 125�� �� *type+�� $��
בניין��$	 125�� �� *
building+�� -   $ new_mal_button��$��חדש��$
��Left=�$��672,398,0,0q�$	��Top=�$��75���� -   $ close_mals_button��$��סגור��$
��Left=�$��492,398,0,0q�$	��Top=�$��75���� -   $ print_sum_button��$��הדפס��$
��Left=�$��
52,398,0,0q�$	��Top=�$��75���� -   $ delete_mals_button��$��מחק��$
��Left=�$��232,398,0,0q�$	��Top=�$��75���� -	   $ delete_all_button��$��מחק הכל��$
��Left=�$��232,449,0,0q�$	��Top=�$��75���� -
   $ exit_button��$��
יציאה��$
��Left=�$��
52,503,0,0q�$	��Top=�$��75���� -    ��Name$ headline_open��$
��Left=�$��
537,27,0,0q�$
��Wrap=�$��תקלות פתוחות��$	��Top=�$��20(� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ 	#FF3E3E3E��   	Direction$	 201Q�   Opacity$
 0.68Q�   ShadowDepth$ 3Q�   
BlurRadius$ 6Q��� -   $ headline_close��$
��Left=�$��
136,27,0,0q�$
��Wrap=�$��תקלות סגורות��$	��Top=�$��20(�   $ 	#FF3E3E3E��$	 201Q�$
 0.68Q�$ 3Q�$ 6Q��� -    ��Name$ 	stateOfDB��$
��Left=�$��30��$��30��$��7,7,0,0q�$��2��$	��Top=��� -   $ mals_img��$
��Left=�$	��130��$��339,429,0,0q�$	��Top=�$	��130��