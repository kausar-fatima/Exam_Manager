   M S B A M L   `   `   `  ����O  KExamManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ExamManagementSystem.viewsExamManagementSystem.views  5   	   0    *ExamManagementSystem.views.DashboardWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:ExamManagementSystem.views     5   	     � Title$  	Dashboard��5   	   $	��640��6   $
��1090��6(    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   ���#1C1F26 � 	Resources 5         PrimaryColor �� Color  AccentColor  BackgroundColor  	TextColor  FieldBackground  BorderColor �� 
TargetType �� Property �� Value �� 
TargetType��%�  &	        &	 !     &	 B     &	 c     &	 �     &	 �     '�� �     7   �� 5   
   $ #001f3f��6/   �� 5   
   $ #0074D9��6.   �� 5   
   $ #1C1F26��62   �� 5   
   $ #ECECEC��6,   �� 5   
   $ #2C2F36��62   �� 5   
   $
 #444��6.   �� 5   
   " ��6   .�5      ��  � ��8   6+   �� 5       � ��
 �����6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$
 10,5q�6(   �� 5       � ��$	 0,5q�6'   �� 5       � ��$ 40��6'   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5       " ��6&   .R�5!      �� #��z��6!   ._�5"      �� $��Center=�6/   $��Center=�6L   5#      5$      5&      5'      5(      .��5*      ]� $
��True��6   .+�5,   
   � $	��Top=�6   $��90��6$   #��[ 60   	 � ColumnDefinitions	 5-      �� 5.      $
��Auto �6#   .+�53      �� $��/Images/exam1.png��6   $��70��6/   $��
53,0,972,0q�6;   $��Center=�6O   �� 56      -   5        
 ��Name$
 WelcomeTextBlock��56      $��1��57       �� TextAlignment$ Center=�58      $��Center=�59      
�������$��18(�5;      $
��Bold"�5<      $��	192,0,0,0q�6&   5=      ]� 5@   
   $
��Left=�6   $	��190��6*   #��[ 66   .+�5C      �� $	��Top=�6   .+�5E      �� -   5         ��Name$ SuperAdminPanel��5E      $y�	Collapsed=�66   .+�5F      �� -   5        $��Manage Users��5F      
 � Tag$ 	UsersPage��64   6D   �� 5G      -   5        $��Manage Roles��5G      $ 	RolesPage��64   6D   5H      �� 5J      -   5        $ 
AdminPanel��5J      $y�	Collapsed=�61   .+�5K      �� -   5        $��Batchs Management��5K      $ 
BatchsPage��69   6J   �� 5L      -   5        $��Rooms Management��5L      $ 	RoomsPage��68   6H   5M      �� 5O      -   5        $ 
ClerkPanel��5O      $y�	Collapsed=�61   .+�5P      �� -	   5        $��Generate Schedule Plans��5P      $ SchedulePlansPage��6?   6W   5Q      5R      �� 5U      -
   5        $��Logout��5U      $��Bottom=�5V      #��[ 5W      $��Bottom=�5X      5Y      5Z       � 5^   
   -   5          �Name$ MainContentFrame��5^        � NavigationUIVisibility$ Hidden=�6*   5_      5b      