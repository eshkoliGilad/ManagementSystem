   M S B A M L   `   `   `  ����   Management_System(    "Management_System.Buildings_report   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .��� $��
10,9,10,11q�  � ColumnDefinitions  �� $
��721* ��� $
��459* �.+��� $��2��$��7,7,3,-7q�.+�&   System.Windows.Controls.DataGrid  -   $��dgUsers��   SelectionUnit$
 Cell=�   SelectionMode$ Single=�   AutoGenerateColumns .  $��
0,52,0,109q�$��2������ *listOfTenants+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 
דצמבר��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
December+ �� Mode$ TwoWay=�	   HeaderStyle	 �� 
 �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"
  .���  �� Property � �� �� Value$ Center=�   ElementStyle �� "
 ��.���  � ��$ Right=�  $ נובמבר��$ *  �� *
November+$ TwoWay=�	 �� "
  .���  � ��$ Center=� �� "
 ��.���  � ��$ Right=�  $ אוקטובר��$ *  �� *	October+$ TwoWay=�	 �� "
  .���  � ��$ Center=� �� "
 ��.���  � ��$ Right=�  $ ספטמבר��$ *  �� *	September+$ TwoWay=�	 �� "
  .���  � ��$ Center=� �� "
 ��.���  � ��$ Right=�  $ אוגוסט��$ *  �� *August+$ TwoWay=�	 �� "
  .���  � ��$ Center=� �� "
 ��.���  � ��$ Right=�  $ יולי��$ *  �� *July+$ TwoWay=�	 �� "
  .���  � ��$ Center=� �� "
 ��.���  � ��$ Right=�  $ יוני��$ *  �� *June+$ TwoWay=�	 �� "
  .���  � ��$ Center=� �� "
 ��.���  � ��$ Right=�  $ מאי��$ *  �� *May+$ TwoWay=�	 �� "
  .���  � ��$ Center=� �� "
 ��.���  � ��$ Right=�  $ 
אפריל��$ *  �� *April+$ TwoWay=�	 �� "
  .���  � ��$ Center=� �� "
 ��.���  � ��$ Right=�  $ מרץ��$ *  �� *March+$ TwoWay=�	 �� "
  .���  � ��$ Center=� �� "
 ��.���  � ��$ Right=�  $ פברואר��$ *  �� *
February+$ TwoWay=�	 �� "
  .���  � ��$ Center=� �� "
 ��.���  � ��$ Right=�  $ 
ינואר��$ *  �� *	January+$ TwoWay=�	 �� "
  .���  � ��$ Center=� �� "
 ��.���  � ��$ Right=�  $ שם דייר��$	 200  �� *Name+	 �� "
  .���  � ��$ Center=� �� "
 ��.���  � ��$ Right=�  $ מס' דירה��$ 60  �� *apartmentNumber+	 �� "
  .���  � ��$ Center=� �� "
 ��.���  � ��$ Right=��� -    ��Name$ back_button��$��חזרה��$
��Left=�$��125,487,0,0q�$	��Top=�$��75��$��1���� -    ��Name$ address_Reports_show��$
��Left=� �� TextAlignment$ Center=�$��
323,11,0,0q�$
��24px(�$
��Wrap=�$	��Top=�$��2��$	��530�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ 	#FF3E3E3E��   	Direction$	 201Q�   Opacity$
 0.68Q�   ShadowDepth$ 3Q�   
BlurRadius$ 6Q��� -   $ save_button��$��
שמירה��$��659,487,446,0q�$	��Top=�$��2���� -    ��Name$ 	stateOfDB��$
��Left=�$��30��$��30��$��7,7,0,0q�$��2��$	��Top=��� -   $ print_report��$��הדפס��$
��Left=�$��273,487,0,0q�$	��Top=�$��75���� -   $ refresh_button��$��רענן��$
��Left=�$��466,487,0,0q�$	��Top=�$��75��