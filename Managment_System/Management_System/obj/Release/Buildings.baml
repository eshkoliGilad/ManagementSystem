   M S B A M L   `   `   `  ����   Management_System!    Management_System.Buildings   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .��� .+��� -   $��buildingslvDataBinding��$
��Left=�$	��251��$��Right=�$��
503,29,0,0q�$	��Top=�$	��260������   �� 
TargetType"  ��.���  �� Property � �� �� Value$	 Top=���  � ��$ Center=� �� View �� .P��� $��
כתובת�� �� Width$	 250�� �� DisplayMemberBinding �� *	Address+�� -    ��Name$ cmd_NewBuilding��$��חדש��$
��Left=�$��686,317,0,0q�$	��Top=�$��75���� -   $ cmd_EditBuilding��$��מחק��$
��Left=�$��505,317,0,0q�$	��Top=�$��75���� -    ��Name$ building_Address��$��30(�$
��Left=�$��
206,29,0,0q�$
��Wrap=�$	��Top=� J� RenderTransformOrigin$ 0.5,0.5&�$	��254��	 J� Effect	 3  -System.Windows.Media.Effects.DropShadowEffect  
   Color$
 	#FF3E3E3E��   	Direction$	 201Q�   Opacity$
 0.68Q�   ShadowDepth$ 3Q�   
BlurRadius$ 6Q��� -   $ account_Number��$
��Left=�$��374,100,0,0q�$
��Wrap=�$��: מס' חשבון בנק��$	��Top=��� -    ��Name$ account_Number_field��$
��Left=�$��23��$��239,100,0,0q� �� TextWrapping$
 Wrap=�{�.  $	��Top=�$	��120���� -   $ floors_text��$
��Left=�$��400,150,0,0q�$
��Wrap=�$��: מס' קומות��$	��Top=��� -   $ number_of_floors_field��{�.  $
��Left=�$��23��$��239,150,0,0q�$
 Wrap=�$	��Top=�$	��120���� -	   $ back_button��$��חזרה��$
��Left=�$��534,523,0,0q�$	��Top=�$��75���� -
   $ exit_button��$��
יציאה��$
��Left=�$��140,523,0,0q�$	��Top=�$��75���� -   $ attendence_box��{�.  $
��Left=�$��23��$��239,201,0,0q�$
 Wrap=�$	��Top=�$	��120���� -   $ attendence_text��$
��Left=�$��387,201,0,0q�$
��Wrap=�$��: מספר דיירים��$	��Top=��� -   $ edit_button��$��ערוך��$
��Left=�$��594,317,0,0q�$	��Top=�$��75���� -   $ check_For_block��$
��Left=�$��415,257,0,0q�$
��Wrap=�$��: לפקודת��$	��Top=��� -   $ check_for_box��{�.  $
��Left=�$��23��$��239,257,0,0q�$
 Wrap=�$	��Top=�$	��120���� -    ��Name$ evelvator_check��$��
מעלית��{�.  $
��Left=�$��153,107,0,0q�$	��Top=��� -   $ garden_check��$��גינה��{�.  $
��Left=�$��153,157,0,0q�$	��Top=��� -   $ heating_check��$��הסקה��{�.  $
��Left=�$��155,208,0,0q�$	��Top=��� -   $ miklat_check��{�.  $��מקלט��$
��Left=�$��156,264,0,0q�$	��Top=��� -   $ garden_name_block��$
��Left=�$��421,310,0,0q�$
��Wrap=�$��:שם גנן��$	��Top=��� -   $ garden_name_box��{�.  $
��Left=�$��23��$��239,310,0,0q�$
 Wrap=�$	��Top=�$	��120���� -   $ garden_name_block_Copy��$
��Left=�$��181,310,0,0q�$
��Wrap=�$��:טלפון��$	��Top=��� -   $ gardner_phone_box��$
��Left=�{�.  $��23��$��
26,310,0,0q�$
 Wrap=�$	��Top=�$	��120���� -   $ garden_name_block_Copy1��$
��Left=�$��396,358,0,0q�$
��Wrap=�$��:מס' מעליות��$	��Top=��� -   $ elevator_num_box��{�.  $
��Left=�$��23��$��239,358,0,0q�$
 Wrap=�$	��Top=�$	��120���� -   $ heating_type_box��{�.  $
��Left=�$��23��$��
26,358,0,0q�$
 Wrap=�$	��Top=�$	��120���� -   $ heating_type_block��$
��Left=�$��160,358,0,0q�$
��Wrap=�$��:סוג חימום��$	��Top=��� -   $ service_type_box��{�.  $
��Left=�$��24��$��239,406,0,0q�$
 Wrap=�$	��Top=�$	��120���� -   $ service_type_block��$
��Left=�$��405,406,0,0q�$
��Wrap=�$��:סוג שירות��$	��Top=��� -   $ meetings��$��אסיפות דיירים��$
��Left=�$��594,402,0,0q�$	��Top=�$	��167���� -   $ print_building��$��הדפס��$
��Left=�$��505,402,0,0q�$	��Top=�$��75���� -     ��Name$ 	stateOfDB��$
��Left=�$��30��$��30��$��7,7,0,0q�$��2��$	��Top=��� -!   $ building_img��$
��Left=�$	��120��$��	10,75,0,0q�$	��Top=�$	��140��