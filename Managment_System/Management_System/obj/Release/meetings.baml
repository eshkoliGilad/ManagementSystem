   M S B A M L   `   `   `  ����   Management_System     Management_System.meetings   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  אסיפות דיירים��$	��481��$	��458�� � WindowStartupLocation$ CenterScreen=�.��� .+��� -   $��TenatsMeetings��$
��Left=�$	��150��$��Right=�$��	28,72,0,0q�$	��Top=�$	��397������  �� 
TargetType" ��.���  �� Property � �� �� Value$	 Top=���  � ��$ Center=� �� View �� .P��� $��
הערות�� �� Width$	 270�� �� DisplayMemberBinding �� *notes+�� $��
תאריך��$	 120�� �� *date+(  "System.Windows.Controls.DatePicker  -     Name$ datepicker_meetings��$
��Left=�$��323,261,0,0q�$	��Top=��� -   	 ��Name$	 notes_meetings_box��$
��Left=�$	��138��$��
28,262,0,0q�
 �� TextWrapping$

 Wrap=�$	��Top=�$	��277���� -    ��Name$ save_button��$��שמור��$
��Left=�$��350,378,0,0q�$	��Top=�$��75���� -   $ cancel_button��$��בטל��$
��Left=�$��350,338,0,0q�$	��Top=�$��75���� -    ��Name$ meetings_Address��$��Center=� �� TextAlignment$ Center=�$	��Top=�$��108,16,102,0q�$
��Wrap=�$��28(� J� RenderTransformOrigin$ 0.5,0.5&�$	��240�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ 	#FF3E3E3E��   	Direction$	 201Q�   Opacity$
 0.68Q�   ShadowDepth$ 3Q�   
BlurRadius$ 6Q��� -   $ delete_metting��$��מחק��$
��Left=�$��350,300,0,0q�$	��Top=�$��75������  �� ImageSource$ /lightSilver.jpg��