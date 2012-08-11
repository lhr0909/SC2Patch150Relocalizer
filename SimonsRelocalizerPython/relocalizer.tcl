
if {![info exists vTcl(sourcing)]} {

    # Provoke name search
    catch {package require bogus-package-name}
    set packageNames [package names]

    package require Tk
    switch $tcl_platform(platform) {
    windows {
            option add *Button.padY 0
    }
    default {
            option add *Scrollbar.width 10
            option add *Scrollbar.highlightThickness 0
            option add *Scrollbar.elementBorderWidth 2
            option add *Scrollbar.borderWidth 2
    }
    }
    
}

#############################################################################
# Visual Tcl v1.60 Project
#




#############################################################################
## vTcl Code to Load Stock Images


if {![info exist vTcl(sourcing)]} {
#############################################################################
## Procedure:  vTcl:rename

proc ::vTcl:rename {name} {
    ## This procedure may be used free of restrictions.
    ##    Exception added by Christian Gavin on 08/08/02.
    ## Other packages and widget toolkits have different licensing requirements.
    ##    Please read their license agreements for details.

    regsub -all "\\." $name "_" ret
    regsub -all "\\-" $ret "_" ret
    regsub -all " " $ret "_" ret
    regsub -all "/" $ret "__" ret
    regsub -all "::" $ret "__" ret

    return [string tolower $ret]
}

#############################################################################
## Procedure:  vTcl:image:create_new_image

proc ::vTcl:image:create_new_image {filename {description {no description}} {type {}} {data {}}} {
    ## This procedure may be used free of restrictions.
    ##    Exception added by Christian Gavin on 08/08/02.
    ## Other packages and widget toolkits have different licensing requirements.
    ##    Please read their license agreements for details.
    # Does the image already exist?
    if {[info exists ::vTcl(images,files)]} {
        if {[lsearch -exact $::vTcl(images,files) $filename] > -1} { return }
    }
    if {![info exists ::vTcl(sourcing)] && [string length $data] > 0} {
        set object [image create  [vTcl:image:get_creation_type $filename]  -data $data]
    } else {
        # Wait a minute... Does the file actually exist?
        if {! [file exists $filename] } {
            # Try current directory
            set script [file dirname [info script]]
            set filename [file join $script [file tail $filename] ]
        }

        if {![file exists $filename]} {
            set description "file not found!"
            ## will add 'broken image' again when img is fixed, for
            ## now create empty
            set object [image create photo -width 1 -height 1]
        } else {
            set object [image create  [vTcl:image:get_creation_type $filename]  -file $filename]
        }
    }

    set reference [vTcl:rename $filename]
    set ::vTcl(images,$reference,image)       $object
    set ::vTcl(images,$reference,description) $description
    set ::vTcl(images,$reference,type)        $type
    set ::vTcl(images,filename,$object)       $filename

    lappend ::vTcl(images,files) $filename
    lappend ::vTcl(images,$type) $object
    set ::vTcl(imagefile,$object) $filename   ;# Rozen
    # return image name in case caller might want it
    return $object
}

#############################################################################
## Procedure:  vTcl:image:get_image

proc ::vTcl:image:get_image {filename} {
    ## This procedure may be used free of restrictions.
    ##    Exception added by Christian Gavin on 08/08/02.
    ## Other packages and widget toolkits have different licensing requirements.
    ##    Please read their license agreements for details.

    set reference [vTcl:rename $filename]

    # Let's do some checking first
    if {![info exists ::vTcl(images,$reference,image)]} {
        # Well, the path may be wrong; in that case check
        # only the filename instead, without the path.

        set imageTail [file tail $filename]

        foreach oneFile $::vTcl(images,files) {
            if {[file tail $oneFile] == $imageTail} {
                set reference [vTcl:rename $oneFile]
                break
            }
        }
    }
    # Rozen. There follows a hack in case one wants to rerun a tcl
    # file which contains a file name where an image is expected.
    if {![info exists ::vTcl(images,$reference,image)]} {
        set ::vTcl(images,$reference,image)  [vTcl:image:create_new_image $filename]
    }
    return $::vTcl(images,$reference,image)
}

#############################################################################
## Procedure:  vTcl:image:get_creation_type

proc ::vTcl:image:get_creation_type {filename} {
    ## This procedure may be used free of restrictions.
    ##    Exception added by Christian Gavin on 08/08/02.
    ## Other packages and widget toolkits have different licensing requirements.
    ##    Please read their license agreements for details.

    switch [string tolower [file extension $filename]] {
        .ppm -
        .jpg -
        .bmp -
        .gif    {return photo}
        .xbm    {return bitmap}
        default {return photo}
    }
}

foreach img {


            } {
    eval set _file [lindex $img 0]
    vTcl:image:create_new_image\
        $_file [lindex $img 1] [lindex $img 2] [lindex $img 3]
}

}
#############################################################################
## vTcl Code to Load User Images

catch {package require Img}

foreach img {

        {{[file join C:/ Users Simon Desktop development SC2Patch150Relocalizer SimonsRelocalizerPython resources buy_me_a_beer.gif]} {user image} user {}}
        {{[file join C:/ Users Simon Desktop development SC2Patch150Relocalizer SimonsRelocalizerPython resources relocalize_button.GIF]} {user image} user {}}
        {{[file join C:/ Users Simon Desktop development SC2Patch150Relocalizer SimonsRelocalizerPython resources relocalization.GIF]} {user image} user {}}
        {{[file join C:/ Users Simon Desktop development SC2Patch150Relocalizer SimonsRelocalizerPython resources voice_asset.GIF]} {user image} user {}}

            } {
    eval set _file [lindex $img 0]
    vTcl:image:create_new_image\
        $_file [lindex $img 1] [lindex $img 2] [lindex $img 3]
}

#################################
# VTCL LIBRARY PROCEDURES
#

if {![info exists vTcl(sourcing)]} {
#############################################################################
## Library Procedure:  Window

proc ::Window {args} {
    ## This procedure may be used free of restrictions.
    ##    Exception added by Christian Gavin on 08/08/02.
    ## Other packages and widget toolkits have different licensing requirements.
    ##    Please read their license agreements for details.

    global vTcl
    foreach {cmd name newname} [lrange $args 0 2] {}
    set rest    [lrange $args 3 end]
    if {$name == "" || $cmd == ""} { return }
    if {$newname == ""} { set newname $name }
    if {$name == "."} { wm withdraw $name; return }
    set exists [winfo exists $newname]
    switch $cmd {
        show {
            if {$exists} {
                wm deiconify $newname
            } elseif {[info procs vTclWindow$name] != ""} {
                eval "vTclWindow$name $newname $rest"
            }
            if {[winfo exists $newname] && [wm state $newname] == "normal"} {
                vTcl:FireEvent $newname <<Show>>
            }
        }
        hide    {
            if {$exists} {
                wm withdraw $newname
                vTcl:FireEvent $newname <<Hide>>
                return}
        }
        iconify { if $exists {wm iconify $newname; return} }
        destroy { if $exists {destroy $newname; return} }
    }
}
#############################################################################
## Library Procedure:  vTcl:DefineAlias

proc ::vTcl:DefineAlias {target alias widgetProc top_or_alias cmdalias} {
    ## This procedure may be used free of restrictions.
    ##    Exception added by Christian Gavin on 08/08/02.
    ## Other packages and widget toolkits have different licensing requirements.
    ##    Please read their license agreements for details.

    global widget
    set widget($alias) $target
    set widget(rev,$target) $alias
    if {$cmdalias} {
        interp alias {} $alias {} $widgetProc $target
    }
    if {$top_or_alias != ""} {
        set widget($top_or_alias,$alias) $target
        if {$cmdalias} {
            interp alias {} $top_or_alias.$alias {} $widgetProc $target
        }
    }
}
#############################################################################
## Library Procedure:  vTcl:DoCmdOption

proc ::vTcl:DoCmdOption {target cmd} {
    ## This procedure may be used free of restrictions.
    ##    Exception added by Christian Gavin on 08/08/02.
    ## Other packages and widget toolkits have different licensing requirements.
    ##    Please read their license agreements for details.

    ## menus are considered toplevel windows
    set parent $target
    while {[winfo class $parent] == "Menu"} {
        set parent [winfo parent $parent]
    }

    regsub -all {\%widget} $cmd $target cmd
    regsub -all {\%top} $cmd [winfo toplevel $parent] cmd

    uplevel #0 [list eval $cmd]
}
#############################################################################
## Library Procedure:  vTcl:FireEvent

proc ::vTcl:FireEvent {target event {params {}}} {
    ## This procedure may be used free of restrictions.
    ##    Exception added by Christian Gavin on 08/08/02.
    ## Other packages and widget toolkits have different licensing requirements.
    ##    Please read their license agreements for details.

    ## The window may have disappeared
    if {![winfo exists $target]} return
    ## Process each binding tag, looking for the event
    foreach bindtag [bindtags $target] {
        set tag_events [bind $bindtag]
        set stop_processing 0
        foreach tag_event $tag_events {
            if {$tag_event == $event} {
                set bind_code [bind $bindtag $tag_event]
                foreach rep "\{%W $target\} $params" {
                    regsub -all [lindex $rep 0] $bind_code [lindex $rep 1] bind_code
                }
                set result [catch {uplevel #0 $bind_code} errortext]
                if {$result == 3} {
                    ## break exception, stop processing
                    set stop_processing 1
                } elseif {$result != 0} {
                    bgerror $errortext
                }
                break
            }
        }
        if {$stop_processing} {break}
    }
}
#############################################################################
## Library Procedure:  vTcl:Toplevel:WidgetProc

proc ::vTcl:Toplevel:WidgetProc {w args} {
    ## This procedure may be used free of restrictions.
    ##    Exception added by Christian Gavin on 08/08/02.
    ## Other packages and widget toolkits have different licensing requirements.
    ##    Please read their license agreements for details.

    if {[llength $args] == 0} {
        ## If no arguments, returns the path the alias points to
        return $w
    }
    set command [lindex $args 0]
    set args [lrange $args 1 end]
    switch -- [string tolower $command] {
        "setvar" {
            foreach {varname value} $args {}
            if {$value == ""} {
                return [set ::${w}::${varname}]
            } else {
                return [set ::${w}::${varname} $value]
            }
        }
        "hide" - "show" {
            Window [string tolower $command] $w
        }
        "showmodal" {
            ## modal dialog ends when window is destroyed
            Window show $w; raise $w
            grab $w; tkwait window $w; grab release $w
        }
        "startmodal" {
            ## ends when endmodal called
            Window show $w; raise $w
            set ::${w}::_modal 1
            grab $w; tkwait variable ::${w}::_modal; grab release $w
        }
        "endmodal" {
            ## ends modal dialog started with startmodal, argument is var name
            set ::${w}::_modal 0
            Window hide $w
        }
        default {
            uplevel $w $command $args
        }
    }
}
#############################################################################
## Library Procedure:  vTcl:WidgetProc

proc ::vTcl:WidgetProc {w args} {
    ## This procedure may be used free of restrictions.
    ##    Exception added by Christian Gavin on 08/08/02.
    ## Other packages and widget toolkits have different licensing requirements.
    ##    Please read their license agreements for details.

    if {[llength $args] == 0} {
        ## If no arguments, returns the path the alias points to
        return $w
    }

    set command [lindex $args 0]
    set args [lrange $args 1 end]
    uplevel $w $command $args
}
#############################################################################
## Library Procedure:  vTcl:toplevel

proc ::vTcl:toplevel {args} {
    ## This procedure may be used free of restrictions.
    ##    Exception added by Christian Gavin on 08/08/02.
    ## Other packages and widget toolkits have different licensing requirements.
    ##    Please read their license agreements for details.
    uplevel #0 eval toplevel $args
    set target [lindex $args 0]
    namespace eval ::$target {set _modal 0}
}
}


if {[info exists vTcl(sourcing)]} {

proc vTcl:project:info {} {
    set base .top68
    namespace eval ::widgets::$base {
        set set,origin 1
        set set,size 1
        set runvisible 1
    }
    set site_4_0 .top68.tNo69.pg0 
    set site_4_0 $site_4_0
    set site_4_1 .top68.tNo69.pg1 
    set site_4_0 $site_4_1
    set site_4_2 .top68.tNo69.pg2 
    set site_4_0 $site_4_2
    set site_5_0 $site_4_0.scr94
    set site_5_0 $site_4_0.scr95
    set site_4_3 .top68.tNo69.pg3 
    set site_4_0 $site_4_3
    namespace eval ::widgets_bindings {
        set tagslist _TopLevel
    }
    namespace eval ::vTcl::modules::main {
        set procs {
        }
        set compounds {
        }
        set projectType single
    }
}
}

#################################
# USER DEFINED PROCEDURES
#

#################################
# VTCL GENERATED GUI PROCEDURES
#

proc vTclWindow. {base} {
    if {$base == ""} {
        set base .
    }
    ###################
    # CREATING WIDGETS
    ###################
    wm focusmodel $top passive
    wm geometry $top 200x200+44+44; update
    wm maxsize $top 3290 1065
    wm minsize $top 104 1
    wm overrideredirect $top 0
    wm resizable $top 1 1
    wm withdraw $top
    wm title $top "page"
    bindtags $top "$top Page all"
    vTcl:FireEvent $top <<Create>>
    wm protocol $top WM_DELETE_WINDOW "vTcl:FireEvent $top <<DeleteWindow>>"

    ###################
    # SETTING GEOMETRY
    ###################

    vTcl:FireEvent $base <<Ready>>
}

proc vTclWindow.top68 {base} {
    if {$base == ""} {
        set base .top68
    }
    if {[winfo exists $base]} {
        wm deiconify $base; return
    }
    set top $base
    ###################
    # CREATING WIDGETS
    ###################
    vTcl:toplevel $top -class Toplevel
    wm focusmodel $top passive
    wm geometry $top 583x227+764+512; update
    wm maxsize $top 3290 1065
    wm minsize $top 104 1
    wm overrideredirect $top 0
    wm resizable $top 1 1
    wm deiconify $top
    wm title $top "SimonsRelocalizer"
    vTcl:DefineAlias "$top" "Toplevel1" vTcl:Toplevel:WidgetProc "" 1
    bindtags $top "$top Toplevel all _TopLevel"
    vTcl:FireEvent $top <<Create>>
    wm protocol $top WM_DELETE_WINDOW "vTcl:FireEvent $top <<DeleteWindow>>"

    ttk::notebook $top.tNo69 \
        -width 584 -height 224 -takefocus {} 
    vTcl:DefineAlias "$top.tNo69" "TNotebook1" vTcl:WidgetProc "Toplevel1" 1
    frame .top68.tNo69.pg0 
    $top.tNo69 add .top68.tNo69.pg0 \
        -padding 0 -sticky nsew -state normal -text Relocalize -image {} \
        -compound none -underline -1 
    set site_4_0  $top.tNo69.pg0
    ttk::button $site_4_0.tBu70 \
        -takefocus {} -text Tbutton \
        -image [vTcl:image:get_image [file join C:/ Users Simon Desktop development SC2Patch150Relocalizer SimonsRelocalizerPython resources relocalize_button.GIF]] 
    vTcl:DefineAlias "$site_4_0.tBu70" "TButton1" vTcl:WidgetProc "Toplevel1" 1
    ttk::combobox $site_4_0.tCo71 \
        -textvariable combobox -takefocus {} 
    vTcl:DefineAlias "$site_4_0.tCo71" "TCombobox1" vTcl:WidgetProc "Toplevel1" 1
    ttk::combobox $site_4_0.tCo72 \
        -textvariable combobox -takefocus {} 
    vTcl:DefineAlias "$site_4_0.tCo72" "TCombobox2" vTcl:WidgetProc "Toplevel1" 1
    ttk::label $site_4_0.tLa73 \
        -relief flat -textvariable localeText 
    vTcl:DefineAlias "$site_4_0.tLa73" "TLabel1" vTcl:WidgetProc "Toplevel1" 1
    ttk::label $site_4_0.tLa75 \
        -relief flat -textvariable assetText 
    vTcl:DefineAlias "$site_4_0.tLa75" "TLabel2" vTcl:WidgetProc "Toplevel1" 1
    ttk::label $site_4_0.tLa76 \
        -relief flat -text Tlabel \
        -image [vTcl:image:get_image [file join C:/ Users Simon Desktop development SC2Patch150Relocalizer SimonsRelocalizerPython resources relocalization.GIF]] 
    vTcl:DefineAlias "$site_4_0.tLa76" "TLabel3" vTcl:WidgetProc "Toplevel1" 1
    ttk::label $site_4_0.tLa77 \
        -relief flat -text Tlabel \
        -image [vTcl:image:get_image [file join C:/ Users Simon Desktop development SC2Patch150Relocalizer SimonsRelocalizerPython resources voice_asset.GIF]] 
    vTcl:DefineAlias "$site_4_0.tLa77" "TLabel4" vTcl:WidgetProc "Toplevel1" 1
    ttk::checkbutton $site_4_0.tCh79 \
        -variable tch79 -takefocus {} -textvariable checkLaunchSC2Text 
    vTcl:DefineAlias "$site_4_0.tCh79" "TCheckbutton1" vTcl:WidgetProc "Toplevel1" 1
    ttk::label $site_4_0.tLa80 \
        -relief flat -textvariable pingMessageText 
    vTcl:DefineAlias "$site_4_0.tLa80" "TLabel5" vTcl:WidgetProc "Toplevel1" 1
    ttk::label $site_4_0.tLa82 \
        -relief flat -textvariable updateMessage 
    vTcl:DefineAlias "$site_4_0.tLa82" "TLabel6" vTcl:WidgetProc "Toplevel1" 1
    place $site_4_0.tBu70 \
        -in $site_4_0 -x 370 -y 10 -anchor nw -bordermode ignore 
    place $site_4_0.tCo71 \
        -in $site_4_0 -x 60 -y 30 -width 296 -height 23 -anchor nw \
        -bordermode ignore 
    place $site_4_0.tCo72 \
        -in $site_4_0 -x 60 -y 80 -width 296 -height 23 -anchor nw \
        -bordermode ignore 
    place $site_4_0.tLa73 \
        -in $site_4_0 -x 60 -y 10 -anchor nw -bordermode ignore 
    place $site_4_0.tLa75 \
        -in $site_4_0 -x 60 -y 60 -anchor nw -bordermode ignore 
    place $site_4_0.tLa76 \
        -in $site_4_0 -x 30 -y 20 -anchor nw -bordermode ignore 
    place $site_4_0.tLa77 \
        -in $site_4_0 -x 30 -y 70 -anchor nw -bordermode ignore 
    place $site_4_0.tCh79 \
        -in $site_4_0 -x 60 -y 110 -anchor nw -bordermode ignore 
    place $site_4_0.tLa80 \
        -in $site_4_0 -x 60 -y 140 -anchor nw -bordermode ignore 
    place $site_4_0.tLa82 \
        -in $site_4_0 -x 60 -y 160 -anchor nw -bordermode ignore 
    frame .top68.tNo69.pg1 
    $top.tNo69 add .top68.tNo69.pg1 \
        -padding 0 -sticky nsew -state normal -text Settings -image {} \
        -compound none -underline -1 
    set site_4_1  $top.tNo69.pg1
    ttk::button $site_4_1.tBu83 \
        -takefocus {} -textvariable btnChangeSC2DirectoryText 
    vTcl:DefineAlias "$site_4_1.tBu83" "TButton2" vTcl:WidgetProc "Toplevel1" 1
    ttk::button $site_4_1.tBu84 \
        -takefocus {} -textvariable btnChangeVarText 
    vTcl:DefineAlias "$site_4_1.tBu84" "TButton3" vTcl:WidgetProc "Toplevel1" 1
    ttk::label $site_4_1.tLa85 \
        -relief flat -textvariable SC2LocationText 
    vTcl:DefineAlias "$site_4_1.tLa85" "TLabel7" vTcl:WidgetProc "Toplevel1" 1
    ttk::label $site_4_1.tLa86 \
        -relief flat -textvariable varTxtLocationText 
    vTcl:DefineAlias "$site_4_1.tLa86" "TLabel8" vTcl:WidgetProc "Toplevel1" 1
    ttk::checkbutton $site_4_1.tCh38 \
        -variable langChinese -takefocus {} -text {Check here for Chinese} \
        -state active 
    vTcl:DefineAlias "$site_4_1.tCh38" "TCheckbutton2" vTcl:WidgetProc "Toplevel1" 1
    place $site_4_1.tBu83 \
        -in $site_4_1 -x 30 -y 10 -anchor nw -bordermode ignore 
    place $site_4_1.tBu84 \
        -in $site_4_1 -x 30 -y 50 -anchor nw -bordermode ignore 
    place $site_4_1.tLa85 \
        -in $site_4_1 -x 110 -y 10 -anchor nw -bordermode ignore 
    place $site_4_1.tLa86 \
        -in $site_4_1 -x 110 -y 50 -anchor nw -bordermode ignore 
    place $site_4_1.tCh38 \
        -in $site_4_1 -x 30 -y 110 -anchor nw -bordermode ignore 
    frame .top68.tNo69.pg2 
    $top.tNo69 add .top68.tNo69.pg2 \
        -padding 0 -sticky nsew -state normal -text About -image {} \
        -compound none -underline -1 
    set site_4_2  $top.tNo69.pg2
    ttk::label $site_4_2.tLa89 \
        -relief flat -textvariable aboutText 
    vTcl:DefineAlias "$site_4_2.tLa89" "TLabel9" vTcl:WidgetProc "Toplevel1" 1
    vTcl::widgets::ttk::scrolledtext::CreateCmd $site_4_2.scr94 \
        -width 125 -height 75 
    vTcl:DefineAlias "$site_4_2.scr94" "Scrolledtext5" vTcl:WidgetProc "Toplevel1" 1

    .top68.tNo69.pg2.scr94.01 configure -background white \
        -height 3 \
        -width 10 \
        -wrap word \
        -xscrollcommand ".top68.tNo69.pg2.scr94.02 set" \
        -yscrollcommand ".top68.tNo69.pg2.scr94.03 set"
    vTcl::widgets::ttk::scrolledtext::CreateCmd $site_4_2.scr95 \
        -width 125 -height 75 
    vTcl:DefineAlias "$site_4_2.scr95" "Scrolledtext6" vTcl:WidgetProc "Toplevel1" 1

    .top68.tNo69.pg2.scr95.01 configure -background white \
        -height 3 \
        -width 10 \
        -wrap word \
        -xscrollcommand ".top68.tNo69.pg2.scr95.02 set" \
        -yscrollcommand ".top68.tNo69.pg2.scr95.03 set"
    place $site_4_2.tLa89 \
        -in $site_4_2 -x 20 -y 10 -anchor nw -bordermode ignore 
    place $site_4_2.scr94 \
        -in $site_4_2 -x 0 -y 0 -width 270 -height 184 -anchor nw \
        -bordermode ignore 
    grid columnconf $site_4_2.scr94 0 -weight 1
    grid rowconf $site_4_2.scr94 0 -weight 1
    place $site_4_2.scr95 \
        -in $site_4_2 -x 300 -y 0 -width 280 -height 184 -anchor nw \
        -bordermode ignore 
    grid columnconf $site_4_2.scr95 0 -weight 1
    grid rowconf $site_4_2.scr95 0 -weight 1
    frame .top68.tNo69.pg3 
    $top.tNo69 add .top68.tNo69.pg3 \
        -padding 0 -sticky nsew -state normal -text Beer -image {} \
        -compound none -underline -1 
    set site_4_3  $top.tNo69.pg3
    ttk::label $site_4_3.tLa96 \
        -relief flat -wraplength 500 \
        -text {Thanks for all the support! If you really like it and like to buy me a beer, you can always drop me some change and I will definitely appreciate it!} 
    vTcl:DefineAlias "$site_4_3.tLa96" "TLabel10" vTcl:WidgetProc "Toplevel1" 1
    ttk::button $site_4_3.tBu97 \
        -takefocus {} -text {Click here to buy me a beer!} 
    vTcl:DefineAlias "$site_4_3.tBu97" "TButton4" vTcl:WidgetProc "Toplevel1" 1
    ttk::label $site_4_3.tLa99 \
        -relief flat -text Tlabel \
        -image [vTcl:image:get_image [file join C:/ Users Simon Desktop development SC2Patch150Relocalizer SimonsRelocalizerPython resources buy_me_a_beer.gif]] 
    vTcl:DefineAlias "$site_4_3.tLa99" "TLabel11" vTcl:WidgetProc "Toplevel1" 1
    place $site_4_3.tLa96 \
        -in $site_4_3 -x 40 -y 10 -width 501 -height 47 -anchor nw \
        -bordermode ignore 
    place $site_4_3.tBu97 \
        -in $site_4_3 -x 220 -y 90 -anchor nw -bordermode ignore 
    place $site_4_3.tLa99 \
        -in $site_4_3 -x 170 -y 70 -anchor nw -bordermode ignore 
    ###################
    # SETTING GEOMETRY
    ###################
    place $top.tNo69 \
        -in $top -x 0 -y 0 -width 584 -height 224 -anchor nw \
        -bordermode ignore 

    vTcl:FireEvent $base <<Ready>>
}

#############################################################################
## Binding tag:  _TopLevel

bind "_TopLevel" <<Create>> {
    if {![info exists _topcount]} {set _topcount 0}; incr _topcount
}
bind "_TopLevel" <<DeleteWindow>> {
    if {[set ::%W::_modal]} {
                vTcl:Toplevel:WidgetProc %W endmodal
            } else {
                destroy %W; if {$_topcount == 0} {exit}
            }
}
bind "_TopLevel" <Destroy> {
    if {[winfo toplevel %W] == "%W"} {incr _topcount -1}
}

Window show .
Window show .top68

