   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089_ [MaterialDesignThemes.Wpf, Version=4.7.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a  �� MergedDictionaries �� Source    BooleanToVisibilityConverter  MenuItemTemplate �� DataType2    ,MahApps.Metro.Controls.HamburgerMenuIconItem � ColumnDefinitions �� RelativeSource �� AncestorType*   $MahApps.Metro.Controls.HamburgerMenu �� Path 7 3MahApps.Styles.ListBoxItem.HamburgerMenuItem.Ripple 0 ,MahApps.Styles.ListBoxItem.HamburgerMenuItem �� BasedOn �� 
TargetType	 �� Property
 �� Value �� 
TargetType �Name �� ClearTypeHint ��Name J� SnapsToDevicePixels �� Mode �� 	Converter ��Name J� Opacity%  MaterialDesignThemes.Wpf.Ripple  Name " MahApps.Brushes.Gray.MouseOver   Feedback �� Triggers P� Property P� Value �� 
TargetName ]� 
Conditions �� Property �� Value'   !MahApps.Metro.Controls.ItemHelper  MahApps.Brushes.AccentBase  MahApps.Brushes.Gray ( $MahApps.Brushes.Gray.SemiTransparent < 8MahApps.Styles.ListBoxItem.HamburgerMenuSeparator.Ripple ,	 (MahApps.Styles.ListBoxItem.HamburgerBase '
 #MahApps.Styles.HamburgerMenu.Ripple # MahApps.Brushes.ThemeBackground  MahApps.Brushes.Text * &MahApps.Templates.HamburgerMenu.Ripple �� Triggers :� RoutedEvent �� TargetProperty  W� From	! W� To" g� Duration&    MahApps.Metro.Controls.SplitView#  Name$   CanResizeOpenPane%   CanResizeOpenPane&   CompactPaneLength'   CompactPaneLength(   DisplayMode)   DisplayMode*   PaneBackground+   PaneBackground,   PaneForeground-   PaneForeground.   PanePlacement/   PanePlacement0   ResizeThumbStyle1   ResizeThumbStyle2   
IsPaneOpen3   MaximumOpenPaneLength4 �� Mode5   MinimumOpenPaneLength6   OpenPaneLength7   Pane8   
PaneMargin9 � RowDefinitions: ]�Name;   PaneHeaderMargin<   HamburgerWidth=   HamburgerHeight>   HamburgerMargin?   HamburgerVisibility@ ��Name"A   HamburgerMenuHeaderTemplate1   +MahApps.Metro.Controls.HamburgerMenuListBoxB  NameC   OpenPaneLength"D   VerticalScrollBarOnLeftSide/   )MahApps.Metro.Controls.ScrollViewerHelper"E   VerticalScrollBarOnLeftSide4  .System.Windows.Automation.AutomationPropertiesF   NameG �� IsTextSearchEnabled " HamburgerMenuItemStyleSelectorH   ItemTemplateI   ItemTemplateSelectorJ   ItemsSourceK �� SelectionModeL �� SelectedIndexM �� SelectedItem ) %HamburgerMenuItemOptionsStyleSelectorN   OptionsItemTemplate"O   OptionsItemTemplateSelectorP   OptionsItemsSourceQ   Content8   2MahApps.Metro.Controls.TransitioningContentControlR  NameS �� ContentStringFormat'T    RestartTransitionOnContentChangeU   ContentTransitionV   
TransitionW ��NameX   AutomationIdY   HamburgerButtonHelpTextZ   HelpText[   HamburgerButtonName\   HamburgerButtonTemplate]   HamburgerButtonStyle�� 5      H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml     5      Cmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5      FmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        5      �� 5   
   $I Cpack://application:,,,/MahApps.Metro;component/Styles/Controls.xaml?�6   %o(  &	        &	      &	 �    7  7   &	 ,    7 	 &	
     &	 m    7  7  �� 5      6#   �� 5      "   6,   .R�5   
   � $��48��6    5      �� 5      ��6#   ��  �� "  $ CompactPaneLength��� 5      .+�5      �� $��0��5      $��Center=�5      $��Center=�5      $|�False��5      $��False��5      ��5      �� *Icon+5      �� 5      $��1��5      $��Center=�5      $��16(�5      ��5      �� *Label+5       5!      �� 5$      8   " ��5'   	   .�5(   
   �� 	 � ��
 5)      �� 5*      " ��6"   .R�5+      � $ RootGrid��5,      
������ # z 5.      .+�5/      �� $ Border��50      #��z��51      #��z��52      #��z��53      # z 54      � 55      #��z��6   .+�56      � $
��Left=�57   !   $��Center=�58   !   y�59   !   ��  �� *FindAncestor+"  $ ShowSelectionIndicator�$ OneWay=�8  .+�5:   "   �� $ SelectionIndicator��5;   %   $	��3.5��5<   %   $��48��5=   %   $|�False��5?   %   $	 0.0Q�5@   %   ��5>   %   ��  �� *TemplatedParent+$. ((mah:ItemHelper.SelectedForegroundBrush)�$ OneWay=�5@   %   5A        5B      $ ContentPresenter��5C   !   #��z��5D   !   #��z��5E   !   #��z��5F   !   #��z��5G   !   #��z��5H   !   #��z��5I   !   # �  5J   !   $|�False��5K   !   # z 5L   !   5M      5N       5P      P� 5Q       �@��
IsSelected$
 True��68   . �5R      �� $ Border��6%   
 6O   ��  �� *TemplatedParent+$. ((mah:ItemHelper.SelectedBackgroundBrush)�$ OneWay=�	 � ���� 5S      $ ContentPresenter��6%   
 6Y   ��  �� *TemplatedParent+$. ((mah:ItemHelper.SelectedForegroundBrush)�$ OneWay=�	 � ���� 5T      $ SelectionIndicator��6%   	 �@J�Opacity$	
 1.0Q�6X   5U      ]� 5V       5W      �� 5X   "    �@��
IsSelected$
 True��6B   �� 5Y   "    �@��IsSelectionActive$
 True��6R   ./�5[      �� $ Border��6%   
 6O   ��  �� *TemplatedParent+$5 /(mah:ItemHelper.ActiveSelectionBackgroundBrush)�$ OneWay=�	 � ���� 5\      $ ContentPresenter��6%   
 6Y   ��  �� *TemplatedParent+$5 /(mah:ItemHelper.ActiveSelectionForegroundBrush)�$ OneWay=�	 � ���� 5]      $ SelectionIndicator��6%   
 6U   ��  �� *TemplatedParent+$5 /(mah:ItemHelper.ActiveSelectionForegroundBrush)�$ OneWay=�	 � ��5^      ]� 5`       5a      �� 5b   "    �@J�IsMouseOver$
 True��6C   �� 5c   "    �@��
IsSelected$
 True��6B   ./�5e      �� $ Border��6%   
 6O   ��  �� *TemplatedParent+$3 -(mah:ItemHelper.HoverSelectedBackgroundBrush)�$ OneWay=�	 � ���� 5f      $ ContentPresenter��6%   
 6Y   ��  �� *TemplatedParent+$3 -(mah:ItemHelper.HoverSelectedForegroundBrush)�$ OneWay=�	 � ���� 5g      $ SelectionIndicator��6%   
 6U   ��  �� *TemplatedParent+$3 -(mah:ItemHelper.HoverSelectedForegroundBrush)�$ OneWay=�	 � ��5h      ]� 5i       5j      �� 5k   "    �@J�IsMouseOver$
 True��6C   �� 5l   "    �@��
IsSelected$ False��6B   ./�5n      �� $ Border��6%   
 6O   ��  �� *TemplatedParent+$+ %(mah:ItemHelper.HoverBackgroundBrush)�$ OneWay=�	 � ���� 5o      $ ContentPresenter��6%   
 6Y   ��  �� *TemplatedParent+$+ %(mah:ItemHelper.HoverForegroundBrush)�$ OneWay=�	 � ���� 5p      $ SelectionIndicator��6%   
 6U   ��  �� *TemplatedParent+$+ %(mah:ItemHelper.HoverForegroundBrush)�$ OneWay=�	 � ��5q      P� 5s        �@ IsMouseLeftButtonPressed$
 True��6U   . �5t      �� $ Border��6%   
 6O   ��  �� *TemplatedParent+$< 6(mah:ItemHelper.MouseLeftButtonPressedBackgroundBrush)�$ OneWay=�	 � ���� 5u      $ ContentPresenter��6%   
 6Y   ��  �� *TemplatedParent+$< 6(mah:ItemHelper.MouseLeftButtonPressedForegroundBrush)�$ OneWay=�	 � ��5v      P� 5w      ! �@ IsMouseRightButtonPressed$
 True��6V   . �5x      �� $ Border��6%   
 6O   ��  �� *TemplatedParent+$= 7(mah:ItemHelper.MouseRightButtonPressedBackgroundBrush)�$ OneWay=�	 � ���� 5y      $ ContentPresenter��6%   
 6Y   ��  �� *TemplatedParent+$= 7(mah:ItemHelper.MouseRightButtonPressedForegroundBrush)�$ OneWay=�	 � ���� 5z      $ SelectionIndicator��6%   
 6U   ��  �� *TemplatedParent+$< 6(mah:ItemHelper.MouseLeftButtonPressedForegroundBrush)�$ OneWay=�	 � ��5{      P� 5}       � {�$ False��67   . �5~      �� $ Border��6%   
 6O   ��  �� *TemplatedParent+$. ((mah:ItemHelper.DisabledBackgroundBrush)�$ OneWay=�	 � ���� 5      $ ContentPresenter��6%   
 6Y   ��  �� *TemplatedParent+$. ((mah:ItemHelper.DisabledForegroundBrush)�$ OneWay=�	 � ���� 5�      $ RootGrid��6%   
 6Q   ��  �� *TemplatedParent+$ 
Background�$ OneWay=�	 � ���� 5�      $ SelectionIndicator��6%   
 6U   ��  �� *TemplatedParent+$. ((mah:ItemHelper.DisabledForegroundBrush)�$ OneWay=�	 � ��5�      ]� 5�       5�      �� 5�   "    � {�$ False��6A   �� 5�   "    �@��
IsSelected$
 True��6B   ./�5�      �� $ Border��6%   
 6O   ��  �� *TemplatedParent+$6 0(mah:ItemHelper.DisabledSelectedBackgroundBrush)�$ OneWay=�	 � ���� 5�      $ ContentPresenter��6%   
 6Y   ��  �� *TemplatedParent+$6 0(mah:ItemHelper.DisabledSelectedForegroundBrush)�$ OneWay=�	 � ���� 5�      $ SelectionIndicator��6%   
 6U   ��  �� *TemplatedParent+$6 0(mah:ItemHelper.DisabledSelectedForegroundBrush)�$ OneWay=�	 � ��5�      5�      5�      �� 5�   
   &	 �@ ActiveSelectionBackgroundBrush

 ���� 6J   �� 5�   
   &	 �@ ActiveSelectionForegroundBrush#
 �  6J   �� 5�   
   	 �@ DisabledForegroundBrush#
 �  6C   �� 5�   
   '	 �@ DisabledSelectedBackgroundBrush

 ���� 6K   �� 5�   
   '	 �@ DisabledSelectedForegroundBrush#
 �  6K   �� 5�   
   	 �@ HoverBackgroundBrush#
 �  6@   �� 5�   
   $	 �@ HoverSelectedBackgroundBrush#
 �  6H   �� 5�   
   $	 �@ HoverSelectedForegroundBrush#
 �  6H   �� 5�   
   	 �@ SelectedBackgroundBrush

 ���� 6C   �� 5�   
   	 �@ SelectedForegroundBrush#
 �  6C   5�      �� 5�      8   " ��5�   	   .�5�   
   �� 	 �@�FocusVisualStyle
 6-   Z� �� 5�   
   	 � |�$
 False��6&   �� 5�   
   	 �@J�IsHitTestVisible$

 True��6-   �� 5�   
   	 � ��$
 False��6&   �� 5�   
   	 � ��$
 30,20,30,20q�6#   �� 5�   
   	 � ��
 5�      �� 5�      " ��6"   .R�5�      � #��z��6   # z 6E   .+�5�      �� #��z��5�      #��z��5�      #��z��5�      # z 5�      5�      5�      5�      5�      �� 5�      "  68   .�5�   
   �� 	 �@ ItemContainerStyle#
 �  6/   �� 5�   
   !	 �@ OptionsItemContainerStyle#
 �  66   �� 5�   
   #	 �@ SeparatorItemContainerStyle#
 �  68   �� 5�   
   	 �@ PaneBackground#
 �  6+   �� 5�   
   	 �@ PaneForeground#
 �  6+   �� 5�   
   	 �@ ShowSelectionIndicator$

 True��63   �� 5�   
   	 � ��#
 �  6%    5�   
   :� 5�      $ Loaded��6   .[�5�      �� .��5�      �� .��5�      W� $ Opacity�5�        0.55�      ! 1.05�      $" 0:0:1D�5�      5�      5�      5�      5�      �� 5�      "  6E   .R�5�   
   � .+�5�        $# MainSplitView��5�      #% z$ 5�      #' z& 5�      #) z( 5�      $��False��5�      #+ z* 5�      #- z, 5�      #/ z. 5�      #1 z0 5�      2 5�      �� *
IsPaneOpen+$ TwoWay=� �� *TemplatedParent+3 5�      ��  �� $4 TemplatedParent=�$ MaximumOpenPaneLength�5 5�      ��  �� $4 TemplatedParent=�$ MinimumOpenPaneLength�6 5�      ��  �� $4 TemplatedParent=�$ OpenPaneLength�$ TwoWay=�7 5�      � 5�      $ PaneGrid��6   #��z8 6-   9 5�      �� 5�      $
��Auto �6,   �� 5�      $��* �6,   �� 5�      $
��Auto �6,   .+�5�      ]� $: 
PaneHeader��5�      $��0��5�      #��z; 5�      $
��True��5�      .+�5�      � $ HamburgerButtonSpace��5�   !   #��z< 5�   !   #��z= 5�   !   #��z> 5�   !   $
��Left=�5�   !   #y�z? 5�   !   �� 5�      $@ PaneHeaderContent��5�   !   $��Stretch=�5�   !   #��zA 5�   !   $��False��5�   !   5�        5�      $B ButtonsListView��5�      $��1��5�      #��zC 5�      #E zD 5�      $F 
Menu items��5�      #��z, 5�      $G False��5      8��  #��zH 5     #��zI 5     #��zJ 5     $
��Auto=�5     $K Single=�5     $��1��5	     L 5     ��  �� *TemplatedParent+$ SelectedIndex�$ TwoWay=�M 5     ��  �� *TemplatedParent+$ SelectedItem�$ TwoWay=�5	       5
     $B OptionsListView��5     $��2��5     #��zC 5     $��0,20,0,0q�5     $��Bottom=�5     $F Option items��5     #��z, 5     $G False��5     8�� #��zN 5     #��zO 5     #��zP 5     $��Disabled=�5     $K Single=�5     $��2��5     L 5     ��  �� *TemplatedParent+$ SelectedOptionsIndex�$ TwoWay=�M 5     ��  �� *TemplatedParent+$ SelectedOptionsItem�$ TwoWay=�5     5     .Q 5       $R ContentPart��5     #��z��5      #��z��5!     #��z��5"     $F Content��5#     #��z��5$     #S zS 5%     #��z��5&     #��z��5'     $
T True��5(     # z 5)     #V zU 5*     5+     �� 5,     $W HamburgerButton��5-     #��z< 5.     #��z= 5/     #��z> 50     $
��Left=�51     $	��Top=�52     $X HamburgerButton��53     #Z zY 54     #F z[ 55     #��z\ 56     #��z, 57     #��z��58     #��z] 59     $��0��5:     #y�z? 5;     5<      5=  
   P� 5>      �@ PanePlacement$ Right=�6/   . �5?     �� $ HamburgerButton��6   	 � ��$
 Right=�6U   �� 5@     $ HamburgerButtonSpace��6   	 � ��$
 Right=�6U   5A     5C     5D     