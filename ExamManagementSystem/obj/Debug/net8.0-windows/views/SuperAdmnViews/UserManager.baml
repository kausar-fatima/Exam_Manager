   M S B A M L   `   `   `  ����O  KExamManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:ExamManagementSystem.views.SuperAdmnViews)ExamManagementSystem.views.SuperAdmnViews  5      ;    5ExamManagementSystem.views.SuperAdmnViews.UserManager   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ilocal7clr-namespace:ExamManagementSystem.views.SuperAdmnViews     5      $	��500��5      $	��800��5	        N� Title$  UserManager��5
       N� 
Background �#1C1F26 � 	Resources 5         PrimaryColor �� Color  AccentColor  BackgroundColor  	TextColor  FieldBackground  BorderColor �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius&   System.Windows.Controls.DataGrid=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%_  &	        &	 !     &	 B     &	 c     &	 �     &	 �     '�� �     7  '�� �    7  '      7  7  7  '  1    7  7   �� 5   
   $ #001f3f��6/   �� 5   
   $ #0074D9��6.   �� 5   
   $ #1C1F26��62   �� 5   
   $ #ECECEC��6,   �� 5   
   $ #2C2F36��62   �� 5   
   $
 #444��6.   �� 5   
   " ��6   .�5      ��  � ��8   6+   �� 5       � ��
 �����6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$
 10,5q�6(   �� 5       � ��$
 0,10q�6'   �� 5       � ��$ 40��6'   �� 5       �@�Cursor$
 Hand��6'   �� 5        � �� 5!      �� 5"      " ��6&   .R�5#      �� #��z��6!   $ 20��6K   ._�5$      �� $��Center=�6/   $��Center=�6L   5%      5&      5(      5)      �� 5+   
   " ��6   .�5,      ��  � ��8   6+   �� 5-       � ��$ 16(�6)   5.      �� 50   
   "  6   .�51      ��  � ��8   6+   �� 52       � ��8  6+   �� 53       � ��8  6,   �� 54       � ��$ 1q�60   �� 55       � ��$ Stretch=�64   �� 56       � ��$ Stretch=�62   �� 57       � ��$ 0,10,0,0q�6'   58      �� 5:   
   "  6   .�5;      ��  � ��8   6+   �� 5<       � ��8  6+   �� 5=       � ��$ 40��6'   �� 5>       � ��$
 Bold"�6+   5?      5@      .��5B      � $��20q�6   	 � RowDefinitions	 5C   
   �� 5D      $
��Auto �6   �� 5E      $��* �6   .+�5H   
   �� $��Manage Users��6   $��24(�6(   $
��Bold"�66   #��[ 5I      $��Center=�6>   $��0,0,0,20q�6[     5K   
   -   5        
  Name$
 UsersDataGrid��5K      $��1��6*      AutoGenerateColumns$ False��67      CanUserAddRows$
 True��5L         
IsReadOnly$
 True��6)      SelectionMode$ Single=�6;   $��0,10,0,0q�5M      "   VerticalScrollBarVisibility$
 Auto=�6%      RowBackground# [ 5N         AlternatingRowBackground# [ 5P         Columns 5R      0  *System.Windows.Controls.DataGridTextColumn  5S      ,  &System.Windows.Controls.DataGridColumn   Header$ Username��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *
Username+   ElementStyle 5T      �� 5U      " ��6    .�5V      ��  � ��$ Center=�6B   5W      5Y        5[      $
 Role��6%   $	 150 6L    63   �� *Role+ 5\      �� 5]      " ��6    .�5^      ��  � ��$ Center=�6B   5_      5a      4  .System.Windows.Controls.DataGridTemplateColumn  5c      $ Actions��6)   $	 200 6:      CellTemplate 5d      �� 5e      .R�5f      ��  �� Orientation$ 
Horizontal=�6)   $��Center=�6B   .+�5g   "   �� -   5        $
��Edit��5g   )   $��80��68   $��40��6C   $��	5,10,5,10q�6O   6b   �� 5h   "   -   5        $��Delete��5h   )   $��80��6:   $��40��6E   $��	5,10,5,10q�6Q   6d   5i      5j      5l      5n      5o      5p      