   M S B A M L   `   `   `  ����L  HManagement_System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Management_SystemManagement_System  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5          Management_System.Login   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      /localclr-namespace:Management_System    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      6sys&clr-namespace:System;assembly=mscorlib     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5          >�Name$  LoginControl��5       � 	Resources 5         Management_System.Ticker 
  ticker��%   &	          5   
   6   5      .��5      � .+�5   
   �� -   5         ��Name$ company_logo��5      $��322,76,282,298q�6&   $
��Fill=�6?   �� 5   
   -   5         ��Name$ textBok_user��5      $
��Left=�6(   $��23��6C   $��343,341,0,0q�6O    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��125��6�   G� 5   
   -   5         G�Name$ textBox_password��5      $
��Left=�60   $��345,415,0,0q�6K   $	��Top=�6`   $	��123��6x   �� 5   
   -   5         ��Name$ Login_Button��5      $��
כניסה��6(   $
��Left=�68   $��345,476,0,0q�6S   $	��Top=�6h   $	��123��6�   6�   �� 5   
   -   5         ��Name$ Block_password��5      $
��Left=�6,   $��534,419,0,0q�6G   $
��Wrap=�6\   $��:סיסמא��6p   $	��Top=�6~   �� 5   
   -   5        $ 
block_user��5      $
��Left=�6(   $��505,348,0,0q�6C   $
��Wrap=�6X   $��:שם משתמש��6l   $	��Top=�6}   �� 5   
   -   5        $ tbArrivalDateTime��5      $	��Top=�5      $��
557,14,0,0q�5      $��20(�5      $
��Left=�5      $
��Wrap=�6/   $��47��6C   $	��223��6O   ��5      ��  �� Source# [  	 �� Path$		 Now�
 �� Mode$
 OneWay=� �� StringFormat$ {0:dd-MMM-yyyy HH:mm:ss}��5   O   �� 5    
   -	   5        $ as_one��5       $
��Left=�6    $	��100��6;   $��534,148,0,0q�6H   $	��Top=�6]   $	��162��6u   �� 5!   
   -
   5        $ as_two��5!      $
��Left=�6    $	��100��6;   $��142,135,0,0q�6H   $	��Top=�6]   $	��250��6u   �� 5"   
   -   5        $ try_to_connect��5"      
�������$
��Left=�6F   $��291,530,0,0q�6a   $
��Wrap=�6v   $$��מנסה להתחבר לרשת��6�   $	��Top=�6�   $��26(�6�   $	��262��6�   $��42��6�   $y�	Collapsed=�6�    J� Effect 5#      3  -System.Windows.Media.Effects.DropShadowEffect  5$         Color$ 	#FF3E3E3E��6#      	Direction$	 201Q�65      Opacity$
 0.68Q�6E      ShadowDepth$ 3Q�6T      
BlurRadius$ 6Q�6d   5%   "   �� 5&   
   -   5        $	 tmp��5&      $
��Left=�6   $��23��6:   $y�	Collapsed=�6F   $��
88,530,0,0q�6]   $
 Wrap=�6q   $	��Top=�6�   $	��120��6�   $	��bla��6�   5'      5(      