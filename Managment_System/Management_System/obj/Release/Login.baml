   M S B A M L   `   `   `  ���� L  HManagement_System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Management_SystemManagement_System  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem     Management_System.Login   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    /localclr-namespace:Management_System    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6sys&clr-namespace:System;assembly=mscorlib     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -     >�Name$  LoginControl�� � 	Resources    Management_System.Ticker 
  ticker��%   &	          .��� .+��� -    ��Name$ company_logo��$��322,76,282,298q�$
��Fill=��� -    ��Name$ textBok_user��$
��Left=�$��23��$��343,341,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��125��G� -    G�Name$ textBox_password��$
��Left=�$��345,415,0,0q�$	��Top=�$	��123���� -    ��Name$ Login_Button��$��
כניסה��$
��Left=�$��345,476,0,0q�$	��Top=�$	��123���� -    ��Name$ Block_password��$
��Left=�$��534,419,0,0q�$
��Wrap=�$��:סיסמא��$	��Top=��� -   $ 
block_user��$
��Left=�$��505,348,0,0q�$
��Wrap=�$��:שם משתמש��$	��Top=��� -   $ tbArrivalDateTime��$	��Top=�$��
557,14,0,0q�$��20(�$
��Left=�$
��Wrap=�$��47��$	��223������  �� Source# [  	 �� Path$		 Now�
 �� Mode$
 OneWay=� �� StringFormat$ {0:dd-MMM-yyyy HH:mm:ss}���� -	   $ as_one��$
��Left=�$	��100��$��534,148,0,0q�$	��Top=�$	��162���� -
   $ as_two��$
��Left=�$	��100��$��142,135,0,0q�$	��Top=�$	��250���� -   $ try_to_connect��
�������$
��Left=�$��291,530,0,0q�$
��Wrap=�$$��מנסה להתחבר לרשת��$	��Top=�$��26(�$	��262��$��42��$y�	Collapsed=� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ 	#FF3E3E3E��   	Direction$	 201Q�   Opacity$
 0.68Q�   ShadowDepth$ 3Q�   
BlurRadius$ 6Q��� -   $	 tmp��$
��Left=�$��23��$y�	Collapsed=�$��
88,530,0,0q�$
 Wrap=�$	��Top=�$	��120��$	��bla��