   M S B A M L   `   `   `  ����G  CWyszukiwarka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WyszukiwarkaWyszukiwarka  5   	       Wyszukiwarka.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Wyszukiwarka     5   	     � Title$  
MainWindow��5	   	   $
��auto��6   $	��475��6*   $
��1100��6:   .��5
      ��  �� Orientation$ Vertical=�6   $
��auto��6(   ���	#FF350000.+�5   
   � -   5         �Name$ GridUI��5      $��75��6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $
��auto �6#   �� 5      $
��auto �6#   �� 5      $
��auto �6#   .+�5      �� $��0��6   $ 
Horizontal=�6)   .+�5      �� $��25��6   
�������.��68   
Folder*:6B   �� 5      -   5         ��Name$ tbxPath��5      $	��300��6+   $��25��67   $��	5,20,0,20q�6C   6Y   �� 5      -   5         ��Name$ btnChooseDir��5      $��25��6/   $��
0,10,30,10q�6V   .��6j   V6m   5      �� 5      $��1��6   $ 
Horizontal=�6)   .+�5      �� $��25��6   
�������.��67   Text:6>   �� 5      -   5        $ tbxSName��5      $	��100��6,   $��25��68   $��0, 10, 10,10q�6D   6\   �� 5      $��25��6   
�������.��67   Rozszerzenie:6F   �� 5      -   5        $ tbxSEntention��5      $	��100��61   $��25��6=   $��0, 10, 10,10q�6I   6a   5      �� 5"      $��2��6   $ 
Horizontal=�6)   .+�5#      �� -   5        $ btnFind��5#      $	��100��6*   $��25��66   $��20,10,10,10q�6X   .��6m   
Wyszukaj6w   �� 5$      -   5         ��Name$ lblLoadedCount��5$      $��25��60   $	��100��6<    J� Opacity$
 0.25Q�6H   $��Italic$�6W   $��10(�6j   
�������.��6�   Załadowano: 06�   5%      �� 5&      $��3��6   $ 
Horizontal=�6)   $��Center=�6B   .+�5'      �� -   5        $ lblLoadning��5'      6/   5(      5)      �� 5*   
   
���   �
�������$��2q�5,      ._�5-   
   � $
��auto��6   $	��350��6    � RowDefinitions 5.      �� 5/      $��* �6    .+�51      �� $��0��6   $
��Auto=�6,   .��52      � -	   5        $ 	ViewFiles��52       53      �� 54      �� 55      58      59      5:      5;      5<      5?      