   M S B A M L   `   `   `  ����O  KExamManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:ExamManagementSystem.views.SuperAdmnViews)ExamManagementSystem.views.SuperAdmnViews  5   	   ;    5ExamManagementSystem.views.SuperAdmnViews.RoleManager   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Ilocal7clr-namespace:ExamManagementSystem.views.SuperAdmnViews     5   	     N� Title$  RoleManager��5   	   $	��500��5	   	   $	��800��5
   	    N� 
Background �#1C1F26 � 	Resources 5         PrimaryColor �� Color  AccentColor  BackgroundColor  	TextColor  FieldBackground  BorderColor �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius  RoundedTextBoxStyle	 ��Name&   System.Windows.Controls.DataGrid=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%o  &	        &	 !     &	 B     &	 c     &	 �     &	 �     '�� �     7  &	 �    '�� �    7  '      7  7  7  '  7    7  7   �� 5   
   $ #001f3f��6/   �� 5   
   $ #0074D9��6.   �� 5   
   $ #1C1F26��62   �� 5   
   $ #ECECEC��6,   �� 5   
   $ #2C2F36��62   �� 5   
   $
 #444��6.   �� 5   
   " ��6   .�5      ��  � ��8   6+   �� 5       � ��
 �����6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$
 10,5q�6(   �� 5       � ��$ 5q�6'   �� 5       � ��$ 35��6'   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5       �� 5!      " ��6&   .R�5"      �� #��z��6!   $ 20��6K   ._�5#      �� $��Center=�6/   $��Center=�6L   5$      5%      5'      5(      �� 5*   
   " ��6   .�5+      ��  � ��$ 32��6'   �� 5,       � ��$ 14(�6)   �� 5-       � ��$
 10,4q�6(   �� 5.       � �� �#2D2D3A6+   �� 5/       � ��
 �����6+   �� 50       � ��
 ���� 6,   �� 51       � ��$ 0q�60   �� 52       � �� 53      �� 54      " ��6&   .R�55      �� #��z��6!   $ 8��56      #��z��57      #��z��58      ._�59      �� $	 PART_ContentHost��6+   $��0q�6E   5:      5;      5=      5>      �� 5A   
   " ��6   .�5B      ��  � ��8   6+   �� 5C       � ��$ 16(�6)   5D      �� 5F   
   "  6   .�5G      ��  � ��8   6+   �� 5H       � ��8  6+   �� 5I       � ��8  6,   �� 5J       � ��$ 1q�60   �� 5K       � ��$ Stretch=�64   �� 5L       � ��$ Stretch=�62   �� 5M       � ��$ 0,10,0,0q�6'   5N      �� 5P   
   "  6   .�5Q      ��  � ��8   6+   �� 5R       � ��8  6+   �� 5S       � ��$ 40��6'   �� 5T       � ��$
 Bold"�6+   5U      5V      .��5Y      � $��20q�6   
 � RowDefinitions
 5Z   
   �� 5[      $
��Auto �6   �� 5\      $��* �6   .+�5`   
   �� $��Role Management��6   $��24(�6+   $
��Bold"�69   #��[ 5a      $��Center=�6>   $��0,0,0,20q�6[   �� 5d   
    �� Orientation$ 
Horizontal=�6   $��0��6.   $��Center=�6;   $��0,0,0,10q�6X   .+�5e      �� $��Enter Role:��6   $��Center=�6+   $��0,0,10,0q�6F   
�������$��14(�6k   $	��120��6y   �� 5f      -   5         ��Name$ RoleNameTextBox��5f      $	��250��6/   #��[ 6;   �� 5g      -   5        $��Add Role��5g      $	��120��6(   64   5h        5k   
   -   5          Name$ RolesDataGrid��5k      $��1��5l         AutoGenerateColumns$ False��5m      "   VerticalScrollBarVisibility$
 Auto=�5n         
IsReadOnly$
 True��5o         SelectionMode$ Single=�5p         HeadersVisibility$ Column=�5q         CanUserAddRows$ False��5r         RowBackground# [ 5s         AlternatingRowBackground# [ 5t         Columns 5v      0  *System.Windows.Controls.DataGridTextColumn  5w      ,  &System.Windows.Controls.DataGridColumn   Header$ Role ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *RoleId+6Q     5x      $ 	Role Name��6%   $ * 6U    68   �� *
RoleName+6U   4  .System.Windows.Controls.DataGridTemplateColumn  5{      $ Update��6)   $	 120 69      CellTemplate 5|      �� 5}      .R�5~      �� -   5        $��Update��5~   %   $��90��6O   5      5�        5�      $ Delete��6)   $	 120 69    5�      �� 5�      .R�5�      �� -   5        $��Delete��5�   %   $��90��6_   
 � Tag 6O   �� 6_   5�      5�      5�      5�      5�      