   M S B A M L   `   `   `  ����  Management_System(    "Management_System.Buildings_report   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      � $��
10,9,10,11q�6     � ColumnDefinitions  5	   
   �� 5
      $
��721* �6   �� 5      $
��459* �6   .+�5   
   �� $��2��6   $��7,7,3,-7q�6)   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��dgUsers��5         SelectionUnit$
 Cell=�6&      SelectionMode$ Single=�6;      AutoGenerateColumns .  $��
0,52,0,109q�6n   $��2��6�   ��6�   �� *listOfTenants+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
דצמבר��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6a   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *
December+ �� Mode$ TwoWay=�6a     5      $ נובמבר��6)   $ * 6b    69   �� *
November+$ TwoWay=�6b     5      $ אוקטובר��6)   $ * 6b    6:   �� *	October+$ TwoWay=�6b     5      $ ספטמבר��6)   $ * 6c    69   �� *	September+$ TwoWay=�6c     5      $ אוגוסט��6)   $ * 6`    69   �� *August+$ TwoWay=�6`     5      $ יולי��6)   $ * 6\    67   �� *July+$ TwoWay=�6\     5      $ יוני��6)   $ * 6\    67   �� *June+$ TwoWay=�6\     5      $ מאי��6)   $ * 6Z    66   �� *May+$ TwoWay=�6Z     5      $ 
אפריל��6)   $ * 6^    68   �� *April+$ TwoWay=�6^     5      $ מרץ��6)   $ * 6\    66   �� *March+$ TwoWay=�6\     5      $ פברואר��6)   $ * 6b    69   �� *
February+$ TwoWay=�6b     5      $ 
ינואר��6)   $ * 6`    68   �� *	January+$ TwoWay=�6`     5      $ שם דייר��6)   $	 200 6S    6:   �� *Name+6S     5      $ מס' דירה��6)   $ 60 6_    6;   �� *apartmentNumber+6_   5      5       �� 5!   
   -   5        	 ��Name$	 back_button��5!      $��חזרה��6&   $
��Left=�65   $��111,487,0,0q�6P   $	��Top=�6e   $��75��6}   $��1��6�   �� 5"   
   -   5        
 ��Name$
 address_Reports_show��5"      $
��Left=�62    �� TextAlignment$ Center=�6M   $��
323,11,0,0q�6d   $
��24px(�6x   $
��Wrap=�6�   $	��Top=�6�   $��2��6�   $	��530��6�    J� Effect 5#      3  -System.Windows.Media.Effects.DropShadowEffect  5$         Color$ 	#FF3E3E3E��6#      	Direction$	 201Q�65      Opacity$
 0.68Q�6E      ShadowDepth$ 3Q�6T      
BlurRadius$ 6Q�6d   5%   "   �� 5&   
   -   5        $	 save_button��5&      $��
שמירה��6&   $��573,487,73,0q�66   $	��Top=�6L   6d   �� 5'   
   -   5         ��Name$ 	stateOfDB��5'      $
��Left=�6#   $��30��6>   $��30��6J   $��7,7,0,0q�6U   $��2��6f   $	��Top=�6w   �� 5(   
   -   5        $	 print_report��5(      $��הדפס��6'   $
��Left=�66   $��337,487,0,0q�6Q   $	��Top=�6f   $��75��6~   6�   5)      5+      