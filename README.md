# AndroidSlidingUpPanelXamarin

Xamarin Bindings library for [Umano's][umano] [AndroidSlidingUpPanel][AndroidSlidingUpPanel]

Plugin is available on [Nuget][Nuget].

# Support

* Feel free to open an issue. Make sure to use one of the templates!
* Commercial support is available. Integration with your app or services, samples, feature request, etc. Email: [hello@baseflow.com](mailto:hello@baseflow.com)
* Powered by: [baseflow.com](https://baseflow.com)

How do I use it?
================

    <com.sothree.slidinguppanel.SlidingUpPanelLayout xmlns:sothree="http://schemas.android.com/apk/res-auto"
      android:id="@+id/sliding_layout"
      android:layout_width="match_parent"
      android:layout_height="match_parent"
      android:gravity="bottom"
      sothree:umanoPanelHeight="68dp"
      sothree:umanoShadowHeight="4dp"
      sothree:umanoParallaxOffset="100dp"
      sothree:umanoDragView="@+id/dragView"
      sothree:umanoOverlay="true">
    <!-- MAIN CONTENT -->
    </com.sothree.slidinguppanel.SlidingUpPanelLayout>
    
Look at the sample project and the original project for more information.

### Licensing

This project is licensed under the [MS-PL License](http://opensource.org/licenses/ms-pl.html)

[umano]: https://github.com/umano
[AndroidSlidingUpPanel]: https://github.com/umano/AndroidSlidingUpPanel
[Nuget]: https://www.nuget.org/packages/Xam.Plugins.Android.SlidingUpPanel/
