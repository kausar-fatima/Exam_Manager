   M S B A M L   `   `   `  ����O  KExamManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:ExamManagementSystem.views.AdmnViews$ExamManagementSystem.views.AdmnViews  5   	   <    6ExamManagementSystem.views.AdmnViews.EditSessionWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlocal2clr-namespace:ExamManagementSystem.views.AdmnViews     5   	     � Title$  EditSessionWindow��5   	   $	��415��5	   	   $	��420��5
   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   ���#1C1F26 � 	Resources 5         PrimaryColor �� Color  AccentColor  BackgroundColor  	TextColor  FieldBackground  BorderColor �� 
TargetType �� Property �� Value �� 
TargetType	 �� CornerRadius
 ��Name��%�  &	        &	 !     &	 B     &	 c     &	 �     &	 �     '�� �     7  7  7  '��     7  �� 5   
   $ #001f3f��6/   �� 5   
   $ #0074D9��6.   �� 5   
   $ #1C1F26��62   �� 5   
   $ #ECECEC��6,   �� 5   
   $ #2C2F36��62   �� 5   
   $
 #444��6.   �� 5   
   " ��6   .�5      ��  � ��8   6+   �� 5       � ��8  6+   �� 5       � ��8  6,   �� 5       � ��$ 1q�60   �� 5       � ��$ 10q�6(   �� 5       � ��$ 
20,0,20,10q�6'   �� 5       � �� 5       �� 5!      " ��6&   .R�5"      �� #��z��6!   #��z��6K   #��z��6w   $	 6��6�   ._�5#      �� $
 PART_ContentHost��6+   5$      5%      5'      5(      �� 5*   
   " ��6   .�5+      ��  � ��8   6+   �� 5,       � ��
 �����6+   �� 5-       � ��$
 Bold"�6+   �� 5.       � ��$
 10,5q�6(   �� 5/       � ��$ 
20,20,20,0q�6'   �� 50       � ��$ 40��6'   �� 51       �@�Cursor$
 Hand��6'   �� 52       � �� 53      �� 54      " ��6&   .R�55      �� #��z��6!   $	 20��6K   ._�56      �� $��Center=�6/   $��Center=�6L   57      58      5:      5;      5=      .��5@      � $��0,40,0,0q�6   .+�5B   
   �� $	��Top=�6   $��2��6-   $	��360��6A   $��	0,-17,0,0q�6N   .+�5E      �� $��Edit Session��6   $��22(�6,   $
��Bold"�6:   #��[ 5F      $��Center=�6>   $��0,0,0,30q�6[   �� 5H      $��SessionName��6   $��SemiBold"�6+   #��[ 6A   $��20,0,0,5q�6i   �� 5I      -   5         ��Name$ SessionTextBox��5I      $��35��6.   �� 5K      $��
Start Date��6   $��SemiBold"�6*   #��[ 6@   $��	20,10,0,5q�6h   (  "System.Windows.Controls.DatePicker  5L      -   5          Name$ StartDatePicker��5L      $��35��62   #��[ 5M      #��[ 5N      #��[ 5O      $��1q�5P      $��
20,0,20,10q�5Q         SelectedDateFormat$ Short=�5R      �� 5T      $��End Date��6   $��SemiBold"�6(   #��[ 6>   $��	20,10,0,5q�6f     5U      -   5        $ EndDatePicker��5U      $��35��60   #��[ 5V      #��[ 5W      #��[ 5X      $��1q�5Y      $��
20,0,20,10q�5Z      $ Short=�5[      �� 5^      -   5        $��Update Session��5^      6.   5_      5`      5a      