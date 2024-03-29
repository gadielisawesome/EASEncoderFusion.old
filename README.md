EASEncoder Fusion is based on the original EASEncoder by SotaJoe.

# Incorrect usage of SAPI voices
There has been a few people confused on how to set them up properly. Here's a tiny guide to help. Although SAPI voices won't be accessible yet until v0.1.4, I thought I would just help clear up confusion, as this guide still applies to regular built-in TTS voices, and works with them.

This is incorrect.

![Incorrect](https://github.com/gadielisawesome/EASEncoderFusion/assets/51249136/d3f5797d-d398-4189-8edd-027a6ba3a8ee)

This is correct.

![Correct](https://github.com/gadielisawesome/EASEncoderFusion/assets/51249136/b64776c0-eab1-4a70-8f2f-b1204f70c15e)

## New features
This enhanced version offers new features that aren't in the original version of EASEncoder:
* Ability to encode EAS messages from raw data.
* National location codes added.
* Mock originator, to prevent actual system activations.
* Made the theme dark.
* Ability to export alerts as wave files (*.wav)
* Some planned features will be implemented, such as the ability to save EAS messages and import it for later use, the ability to decode EAS messages, the ability to change interface color.

## Mock
The mock originator was created to prevent actual system activations.
The originator will also modify the preamble of the message.

From this: `<Preamble>ZCZC-ORG-EEE-PSSCCC+TTTT-JJJHHMM-LLLLLLLL-` 
To this: `0<Preamble>YXYX-ORG-EEE-PSSCCC+TTTT-JJJHHMM-LLLLLLLL-`

The hope of this is to prevent radios and decoders from processing the message as an alert.
If you enable the mock originator and your radio or decoder still records an event, please create an issue with the model of your radio/decoder so I can try and fix it in the next update.

## Build
1. Download or clone this repository.
2. Open the solution with Visual Studio.
3. Right-click each of the projects in the solution and click "Manage NuGet Packages". If it shows any warning about missing NuGet Packages, follow the instructions to restore them.
4. Right-click the solution and click Rebuild Solution.

## EAS S.A.M.E. protocol
According to Wikipedia,
> In the S.A.M.E. system, messages are constructed in four parts, the first and last of which are digital and the middle two are audio. The digital sections of a SAME message are AFSK data bursts, with individual bits lasting 1920 μs (1.92 ms) each, giving a bit rate of 5205⁄6 bits per second. A mark bit is four complete cycles of a sine wave, translating to a mark frequency of 20831⁄3 Hz, and a space bit is three complete sine wave cycles, making the space frequency 1562.5 Hz.
>
> The data is sent isochronously and encoded in 8-bit bytes with the most-significant bit of each ASCII byte set to zero. The least-significant bit of each byte is transmitted first, including the preamble. The data stream is bit and byte synchronized on the preamble.
>
> Since there is no error correction, the digital part of a SAME message is transmitted three times, so that decoders can pick "best two out of three" for each byte, thereby eliminating most errors which can cause an activation to fail.

The text of an EAS message header code is a fixed format.

Format: `<Preamble>ZCZC-ORG-EEE-PSSCCC+TTTT-JJJHHMM-LLLLLLLL-`

This is broken down as follows:
1. A preamble of binary 10101011 (0xAB in hex, and « in ASCII) is repeated sixteen times, used for "receiver calibration" (i.e., clock synchronization), then the letters ZCZC after to ask the decoder to pay attention (a message activation method inherited from NAVTEX).
2. ORG - Originator code, programmed per unit when put into operation:
    * PEP - Primary Entry Point System (President or other authorized national officials)
    * CIV - Civil Authorities (Governor, state/local emergency management, local police/fire officials)
    * WXR - National Weather Service or Environment Canada (Any weather-related alerts)
    * EAS - EAS Participant (Broadcasters, generally only used with test messages)
    * ~~EAN - Emergency Action Notification Network (previously used to send Emergency Action Notifications, no longer used)~~
3. EEE - Event code
    * There are a lot to list, especially since I've added in ALL from Canada and Mexico. Check the source code for a complete list.
4. PSSCCC — Location codes (up to 31 location codes per message), each beginning with a dash character; programmed at time of event.
    * In the United States, the first digit (P) is zero if the entire county or area is included in the warning, otherwise, it is a non-zero number depending on the location of the emergency. The remaining five digits are the FIPS state (SS) and county code (CCC). The entire state may be specified by using county code 000 (three zeros).
    * In Canada, all six digits make up a Canadian Location Code, which corresponds to a specific forecast region as used by the Meteorological Service of Canada. All forecast region numbers are six digits with the first digit always zero.
5. TTTT — Purge time of the alert event (from exact time of issue).
    * In the format hhmm, using 15 minute increments up to one hour, using 30 minute increments up to six hours, and using hourly increments beyond six hours. Weekly and monthly tests sometimes have a 12-hour or greater purge time to assure users have an ample opportunity to verify reception of the test event messages; however; 15 minutes is more common, especially on NOAA Weather Radio's tests.
    * For short term events (like a tornado) this value could be set to 0000 (four zeros), which will purge the warning immediately after the message has been received. However, this is not typical, and FCC guidelines suggest a minimum of 15 minutes purge time.
    * **The purge time is not intended to coincide with the actual end of the event.** Longer events that may not end for days (like hurricanes) may have a purge time of only a few hours. That an event message has been purged does not indicate or imply that the threat has passed.
6. JJJHHMM — Exact time of issue, in UTC, (without time zone adjustments).
    * JJJ is the Ordinal date (day) of the year, with leading zeros
    * HHMM is the hours and minutes (24-hour format), in UTC, with leading zeros
7. LLLLLLLL — Eight-character station callsign identification, with "/" used instead of "–".
[7 Continued] Such as the first eight letters of a cable headend's location, WABC/FM for WABC-FM, KLOX/NWS for a weather radio station programmed from Los Angeles, or EC/GC/CA for a Weatheradio Canada station. This isn't explicity required, and any 8 character string will do.

Each field of the header code is terminated by a dash character, including the station ID at the end; individual PSSCCC location numbers are also separated by dashes, with a plus (+) separating the last location from the purge time that follows it.

You can use the above protocol to encode custom EAS messages in the "Generate EAS from Custom Data" feature. Like this.

![Image consisting of a window with inputs and settings](https://github.com/gadielisawesome/EASEncoderFusion/assets/51249136/0b10359c-7c69-4d4b-8ff4-df360aeb3c92)


## Contributing
If you want to contribute to the software, create a pull request. I will review and merge them.
