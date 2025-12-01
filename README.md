\# ALG-AR-Geotech-Lab

This augmented reality application was developed for the Affordable Learning Georgia (ALG) project to assist undergraduate students in performing geotechnical engineering laboratory tests.

Open this folder as a Unity project, add your own Vuforia license key, and build to Android.

Description:
ALG-AR-Geotech-Lab is an augmented reality (AR) application designed to support undergraduate civil engineering students as they learn standard geotechnical laboratory tests. Instead of relying only on written manuals or short demonstrations, students can hold a mobile device over printed markers in the lab and see 3D equipment, step-by-step instructions, and safety reminders overlaid directly on their physical workspace. The goal is to make each test more intuitive, repeatable, and accessible for students who may be performing the procedure on their own or outside scheduled demonstration times.


The application was developed with support from the Affordable Learning Georgia initiative, with the specific aim of creating freely available, technology-enhanced learning materials. By replacing or supplementing traditional handouts with an interactive AR guide, the project reduces students’ dependence on costly commercial resources while improving clarity of instruction and reducing errors in experimental setup and data collection

From a technical perspective, the project is built using the latest release of Unity 6.0 together with the Vuforia Engine for image-target tracking. Each geotechnical test is implemented as a dedicated Unity scene that includes an AR camera, target image, 3D models of the apparatus, and scripted instruction panels. When the app recognizes the corresponding target in the lab, the digital content appears in place and guides the student through the sequence of actions required for the test. For the initial release, this application provides information and instructions to perform only the moisture content test. With further development, more tests and features will be added.

This repository is intended as both a reusable teaching tool and a reference implementation. Instructors can adapt the scenes to match their own laboratory equipment or add new tests, while students can explore the project to better understand how AR workflows are created for engineering education.
