# -*- coding: utf-8 -*-

# Form implementation generated from reading ui file 'Relocalizer.ui'
#
# Created: Sun Sep 23 11:33:03 2012
#      by: PyQt4 UI code generator 4.9.4
#
# WARNING! All changes made in this file will be lost!
import os

from PyQt4 import QtCore, QtGui

import sys

try:
    _fromUtf8 = QtCore.QString.fromUtf8
except AttributeError:
    _fromUtf8 = lambda s: s

class Ui_RelocalizerMain(object):
    def setupUi(self, RelocalizerMain):
        RelocalizerMain.setObjectName(_fromUtf8("RelocalizerMain"))
        RelocalizerMain.resize(603, 202)
        sizePolicy = QtGui.QSizePolicy(QtGui.QSizePolicy.Fixed, QtGui.QSizePolicy.Fixed)
        sizePolicy.setHorizontalStretch(0)
        sizePolicy.setVerticalStretch(0)
        sizePolicy.setHeightForWidth(RelocalizerMain.sizePolicy().hasHeightForWidth())
        RelocalizerMain.setSizePolicy(sizePolicy)
        RelocalizerMain.setMinimumSize(QtCore.QSize(603, 202))
        RelocalizerMain.setMaximumSize(QtCore.QSize(603, 202))
        icon = QtGui.QIcon()
        icon.addPixmap(QtGui.QPixmap(_fromUtf8("resources/SC2-SimonsRelocalizer.ico")), QtGui.QIcon.Normal, QtGui.QIcon.Off)
        RelocalizerMain.setWindowIcon(icon)
        self.centralwidget = QtGui.QWidget(RelocalizerMain)
        self.centralwidget.setObjectName(_fromUtf8("centralwidget"))
        self.tabWidget = QtGui.QTabWidget(self.centralwidget)
        self.tabWidget.setGeometry(QtCore.QRect(0, 0, 601, 201))
        self.tabWidget.setObjectName(_fromUtf8("tabWidget"))
        self.tab = QtGui.QWidget()
        self.tab.setObjectName(_fromUtf8("tab"))
        self.relocalizeButton = QtGui.QPushButton(self.tab)
        self.relocalizeButton.setGeometry(QtCore.QRect(390, 0, 200, 174))
        self.relocalizeButton.setText(_fromUtf8(""))
        icon1 = QtGui.QIcon()
        icon1.addPixmap(QtGui.QPixmap(os.path.join(sys._MEIPASS, _fromUtf8("resources/new_relocalize_button.jpg"))), QtGui.QIcon.Normal, QtGui.QIcon.Off)
        self.relocalizeButton.setIcon(icon1)
        self.relocalizeButton.setIconSize(QtCore.QSize(195, 169))
        self.relocalizeButton.setObjectName(_fromUtf8("relocalizeButton"))
        self.comboBox = QtGui.QComboBox(self.tab)
        self.comboBox.setGeometry(QtCore.QRect(60, 30, 321, 22))
        self.comboBox.setObjectName(_fromUtf8("comboBox"))
        self.comboBox_2 = QtGui.QComboBox(self.tab)
        self.comboBox_2.setGeometry(QtCore.QRect(60, 80, 321, 22))
        self.comboBox_2.setObjectName(_fromUtf8("comboBox_2"))
        self.localeLabel = QtGui.QLabel(self.tab)
        self.localeLabel.setGeometry(QtCore.QRect(60, 10, 151, 16))
        self.localeLabel.setObjectName(_fromUtf8("localeLabel"))
        self.assetLabel = QtGui.QLabel(self.tab)
        self.assetLabel.setGeometry(QtCore.QRect(60, 60, 141, 16))
        self.assetLabel.setObjectName(_fromUtf8("assetLabel"))
        self.label = QtGui.QLabel(self.tab)
        self.label.setGeometry(QtCore.QRect(30, 30, 25, 25))
        self.label.setText(_fromUtf8(""))
        self.label.setPixmap(QtGui.QPixmap(_fromUtf8("resources/relocalization.png")))
        self.label.setObjectName(_fromUtf8("label"))
        self.label_2 = QtGui.QLabel(self.tab)
        self.label_2.setGeometry(QtCore.QRect(30, 80, 25, 25))
        self.label_2.setText(_fromUtf8(""))
        self.label_2.setPixmap(QtGui.QPixmap(_fromUtf8("resources/voice_asset.png")))
        self.label_2.setScaledContents(False)
        self.label_2.setObjectName(_fromUtf8("label_2"))
        self.pingLabel = QtGui.QLabel(self.tab)
        self.pingLabel.setGeometry(QtCore.QRect(40, 110, 46, 13))
        self.pingLabel.setObjectName(_fromUtf8("pingLabel"))
        self.tabWidget.addTab(self.tab, _fromUtf8(""))
        self.tab_2 = QtGui.QWidget()
        self.tab_2.setObjectName(_fromUtf8("tab_2"))
        self.tabWidget.addTab(self.tab_2, _fromUtf8(""))
        self.tab_3 = QtGui.QWidget()
        self.tab_3.setObjectName(_fromUtf8("tab_3"))
        self.tabWidget.addTab(self.tab_3, _fromUtf8(""))
        self.tab_4 = QtGui.QWidget()
        self.tab_4.setObjectName(_fromUtf8("tab_4"))
        self.tabWidget.addTab(self.tab_4, _fromUtf8(""))
        RelocalizerMain.setCentralWidget(self.centralwidget)

        self.retranslateUi(RelocalizerMain)
        self.tabWidget.setCurrentIndex(0)
        QtCore.QMetaObject.connectSlotsByName(RelocalizerMain)

    def retranslateUi(self, RelocalizerMain):
        RelocalizerMain.setWindowTitle(QtGui.QApplication.translate("RelocalizerMain", "Simon\'s Relocalizer", None, QtGui.QApplication.UnicodeUTF8))
        self.localeLabel.setText(QtGui.QApplication.translate("RelocalizerMain", "Please choose a locale/region:", None, QtGui.QApplication.UnicodeUTF8))
        self.assetLabel.setText(QtGui.QApplication.translate("RelocalizerMain", "Please choose a voice asset:", None, QtGui.QApplication.UnicodeUTF8))
        self.pingLabel.setText(QtGui.QApplication.translate("RelocalizerMain", "Ping: N/A", None, QtGui.QApplication.UnicodeUTF8))
        self.tabWidget.setTabText(self.tabWidget.indexOf(self.tab), QtGui.QApplication.translate("RelocalizerMain", "Relocalize", None, QtGui.QApplication.UnicodeUTF8))
        self.tabWidget.setTabText(self.tabWidget.indexOf(self.tab_2), QtGui.QApplication.translate("RelocalizerMain", "Settings", None, QtGui.QApplication.UnicodeUTF8))
        self.tabWidget.setTabText(self.tabWidget.indexOf(self.tab_3), QtGui.QApplication.translate("RelocalizerMain", "About", None, QtGui.QApplication.UnicodeUTF8))
        self.tabWidget.setTabText(self.tabWidget.indexOf(self.tab_4), QtGui.QApplication.translate("RelocalizerMain", "Beer", None, QtGui.QApplication.UnicodeUTF8))

