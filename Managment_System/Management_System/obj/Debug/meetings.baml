   M S B A M L   `   `   `  ����  Management_System     Management_System.meetings   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  אסיפות דיירים��5   	   $	��481��6   $	��458��6,    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5   
   �� -   5        $��TenatsMeetings��5   ;   $
��Left=�6   $	��150��6.   $��Right=�6   $��	28,72,0,0q�6�   $	��Top=�6�   $	��397��6�   ��5      �� 5	       �� 
TargetType" ��6   .�5
      ��  �� Property � �� �� Value$	 Top=�6A   �� 5       � ��$ Center=�6C   5       �� View 5      �� 5      .P�5      �� $��
הערות��6%    �� Width$	 270��64    �� DisplayMemberBinding 6@   �� *notes+�� 5      $��
תאריך��6%   $	 120��64    6@   �� *date+5      5      (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ datepicker_meetings��5      $
��Left=�62   $��323,261,0,0q�6M   $	��Top=�6b   6z   �� 5   
   -   5        	 ��Name$	 notes_meetings_box��5      $
��Left=�6.   $	��138��6I   $��
28,262,0,0q�6V   
 �� TextWrapping$

 Wrap=�6j   $	��Top=�6~   $	��277��6�   �� 5   
   -   5         ��Name$ save_button��5      $��שמור��6&   $
��Left=�65   $��350,378,0,0q�6P   $	��Top=�6e   $��75��6}   6�   �� 5   
   -   5        $ cancel_button��5      $��בטל��6(   $
��Left=�66   $��350,338,0,0q�6Q   $	��Top=�6f   $��75��6~   6�   �� 5   
   -   5         ��Name$ meetings_Address��5      $��Center=�6.    �� TextAlignment$ Center=�6K   $	��Top=�6b   $��108,16,102,0q�6z   $
��Wrap=�6�   $��28(�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $	��240��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ 	#FF3E3E3E��6#      	Direction$	 201Q�65      Opacity$
 0.68Q�6E      ShadowDepth$ 3Q�6T      
BlurRadius$ 6Q�6d   5   "   �� 5   
   -   5        $ delete_metting��5      $��מחק��6)   $
��Left=�67   $��350,300,0,0q�6R   $	��Top=�6g   $��75��6   6�   5       ��5!      �� 5"   
    �� ImageSource$ /lightSilver.jpg��6   5$      