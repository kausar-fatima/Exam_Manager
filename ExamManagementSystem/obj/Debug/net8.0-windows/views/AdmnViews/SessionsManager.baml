   M S B A M L   `   `   `  ����O  KExamManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:ExamManagementSystem.views.AdmnViews$ExamManagementSystem.views.AdmnViews  5      :    4ExamManagementSystem.views.AdmnViews.SessionsManager   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:ExamManagementSystem.views.AdmnViews     5        N� Title$  SessionsManager��5	       � 	Resources 5         PrimaryColor �� Color  AccentColor  BackgroundColor  	TextColor  FieldBackground  BorderColor  
HoverColor �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius  RoundedTextBoxStyle ��Name&   System.Windows.Controls.DataGrid=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%^  &	        &	 !     &	 B     &	 c     &	 �     &	 �     &	 �     '�� �     7  &	     '  <    7  7  7  '      7   �� 5   
   $ #001f3f��6/   �� 5   
   $ #0074D9��6.   �� 5   
   $ #1C1F26��62   �� 5   
   $ #ECECEC��6,   �� 5   
   $ #2C2F36��62   �� 5   
   $
 #444��6.   �� 5   
   $ #3D566E��6-   �� 5   
   " ��6   .�5      ��  � ��8   6+   �� 5       � ��
 �����6+   �� 5       � ��$ 14(�6)   �� 5       � ��$ SemiBold"�6+   �� 5       � ��$
 10,5q�6(   �� 5       � ��$ 5q�6'   �� 5       � ��$ 35��6'   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5       �� 5!      " ��6&   .R�5"      �� #��z��6!   $ 18��6K   ._�5#      �� $��Center=�6/   $��Center=�6L   5$      5%      5'      �� 5(       � ��$ 0q�60   5)      �� 5,   
   " ��6   .�5-      ��  � ��$ 32��6'   �� 5.       � ��$ 14(�6)   �� 5/       � ��$
 10,4q�6(   �� 50       � �� �#2D2D3A6+   �� 51       � ��
 �����6+   �� 52       � ��$ 35��6'   �� 53       � ��
 ���� 6,   �� 54       � ��$ 0q�60   �� 55       � �� 56      �� 57      " ��6&   .R�58      �� #��z��6!   $ 8��59      #��z��5:      #��z��5;      ._�5<      �� $ PART_ContentHost��6+   $��0q�6E   5=      5>      5@      5A      �� 5D   
   "  6   .�5E      ��  � ��8   6+   �� 5F       � ��8  6+   �� 5G       � ��8  6,   �� 5H       � ��$ 1q�60   �� 5I       � ��$ 0,10,0,0q�6'   �� 5J       �@ RowBackground �#2C2F366.   �� 5K        �@ AlternatingRowBackground �#34384769   �� 5L       �@ 	RowHeight$ 50Q�6*   �� 5M       � ��$ 14(�6)   �� 5N       � ��$ Segoe UI)�6+   5O      �� 5R   
   "  6   .�5S      ��  � ��
 �����6+   �� 5T       � ��8   6+   �� 5U       � ��$
 Bold"�6+   �� 5V       � ��$ 14(�6)   �� 5W       � ��$ 40��6'   5X      5Y      .��5[      � .+�5]      �� $��Center=�6   .+�5_      �� 	 �� Orientation$	 
Horizontal=�6   $
��auto��66   $��Center=�6C   $��0,0,0,10q�6^   $��Center=�6p   .+�5`      �� $��Enter Session:��6    $��Center=�66   
�������$��14(�6d   $	��120��6r   �� 5b      -   5        
 ��Name$
 SessionNameTextBox��5b      $	��254��6:   $��35��6F   #��[ 6R   (  "System.Windows.Controls.DatePicker  5c      -   5          Name$ StartDatePicker��5c   !   $��5q�6:   $��35��6E   #��[ 6Q     5e      -   5        $ EndDatePicker��5e   !   $��5q�68   $��35��6C   #��[ 6O   �� 5g      -   5        $��Add Session��5g      $	��120��6L   5i        5j      -   5          Name$ SessionsDataGrid��5j         AutoGenerateColumns$ False��65   $��0,10,0,0q�6Q      CanUserAddRows$ False��6c   "   VerticalScrollBarVisibility$
 Auto=�6z      Columns 5k      0  *System.Windows.Controls.DataGridTextColumn  5l      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *	SessionId+6W     5m      $
 Name��6-   $ * 6[    6;   �� *SessionName+6[     5n      $ Start��6-   $ * 6Z    6<   �� *	StartDate+6Z     5o      $	 End��6-   $ * 6V    6:   �� *	EndDate+6V   4  .System.Windows.Controls.DataGridTemplateColumn  5p      $ Actions��61   $ * 6B      CellTemplate 5q      �� 5r   "   .R�5s   &   �� $	 
Horizontal=�61   .+�5t   *   �� -   5        $
��Edit��5t   1   $��70��6@   6K   �� 5u   *   -   5        $��Delete��5u   1   $��70��6B   6M   5v   '   5w   #   5y      5{      5|      5~      5      