   M S B A M L   `   `   `  ����E  AYouliOrder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:YouliOrder
YouliOrder  5   	       YouliOrder.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:YouliOrder     5   	   -   5          � Title$  
MainWindow��5   	   $	��700��6   $
��1200��6)    � WindowStyle$
 None=�67    � AllowsTransparency .  � 
ResizeMode$ CanResizeWithGrip=�6�    � WindowStartupLocation$ CenterScreen=�6�    � 	Resources 5	         BtnInfoStyle �� 
TargetType �� Property �� Value	 �� 
TargetType
 ��Name J� SnapsToDevicePixels �� Triggers P� Property P� Value �� 
TargetName��%�  &	        �� 5
   
   " ��6%   .�5      ��  � ��$ 70��6&   �� 5       � ��$ 25��6'   �� 5       � ��
 �   �6+   �� 5       � ��$ 0q�60   �� 5       � �� �#1E73B46+   �� 5       � �� 5      �� 5      "	 ��6&   .R�5      �� $
 border��6!   #��z��61   #��z��6[   #��z��6�    . ._�5      �� #��z��6(   #��z��6I   $��Center=�6s   $��Center=�6�   5       5      P� 5       �@J�IsMouseOver . . �5   "   �� $ border��6)    � �� �#1E73B46S   5      P� 5       � �� . . �5   "   �� $ border��6)    � �� �#1E73B46S   5      5      5       5!      5"      .��5#      �  � ColumnDefinitions 5$   
   �� 5%      $	��250 �6   �� 5&      .+�5)   
   �� ���#3E5B87.+�5*      ��  �� Orientation$ 
Horizontal=�6   $��0,0,0,30q�62   .+�5+      �� $��logo003.png��6   $��20q�6.   $��30��6:   $��30��6E   $
��Left=�6Q   �� 5,      $��优力订单助手��6   $��
0,20,30,20q�6+   $��20(�6?   
�������$��Yu Gothic UI Semibold)�6a   5-      �� 5.      $��0��6   ���#3E5B87��6+   �� *	Modules+��5/      �� 50      .R�51      �� 52      ��55      �� 56      .R�57      �� $��40��6�   $��3q�6�   ��6"   ��  �� RelativeSource ��  �� AncestorType$ local:MainWindowL� �� Path$ DataContext.OpenCommand���6�   �� *Name+��6�   �� *Name+58      5;      5<      � 5=   
   $��1��6    5>      �� 5?       � RowDefinitions 5A      �� 5B      $��30 �6    �� 5C      $��* �6    .+�5E      �� $ 
Horizontal=�6   $��Right=�62   $��0��6N   .+�5F      �� -   5         ��Name$ btnmin��5F      #��[  6)   $��45��6O   $��30��6Z   $	��─��6f   $��0q�6r   
������ 6�   �� 5G      -   5        $ btnmax��5G      #��[  6)   $��45��6O   $��30��6Z   $	��☐��6f   $��0q�6r   
������ 6�   �� 5H      -   5        $ btnclose��5H      #��[  6+   $��45��6Q   $��30��6\   $	��✕��6h   $��0q�6t   
������ 6�   5I      �� 5J      $��1��6   ��6*   �� *Page+5K      5L      5M      