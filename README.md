# Tugas Besar 1 IF2211 Strategi Algoritma
### Pemanfaatan Algoritma Greedy dalam Pembuatan Bot permainan Robocode Tank Royale 
![creators](https://github.com/shanlie20/Tubes1_biskitop/blob/main/doc/image_biskitop.jpg)
### Kelompok 18 - biskitop
| Nama | NIM |
|------|-----|
| Shannon Aurellius Anastasya Lie | 13523019 |
| Jessica Allen | 13523059 |

## Deskripsi Singkat
Algoritma greedy merupakan metode yang paling populer dan sederhana untuk memecahkan persoalan optimasi. Algoritma ini biasanya digunakan untuk menyelesaikan persoalan optimasi (optimization problems) yaitu persoalan mencari solusi optimal. Terdapat dua macam persoalan optimasi yaitu maksimasi (maximization) dan minimasi (minimization). 

Robocode adalah game pemrograman di mana pemain membuat bot virtual yang bertempur di medan perang melawan bot lainnya. Setiap bot dalam Robocode diimplementasikan menggunakan bahasa pemrograman. Program bot di Robocode ini terdiri dari beberapa komponen utama yang saling berinteraksi, seperti pergerakan, pemindaian musuh, penembakan, dan penghindaran tembakan. 

## 4 Bot yang Dibuat
<b>1. Belle (Greedy Center Guard) </b><br/>
Belle menerapkan algoritma yang mengontrol jalur tengah dan siap menyerang balik. Pada algoritma ini, bot akan menuju ke tengah arena pada awal permainan. <br /><br />
<b>2. Ariel (Greedy Center Guard) </b><br />
Ariel menerapkan algoritma yang selalu mengincar musuh terdekat dengan serangan kuat. Pada algoritma ini, bot akan scan, memilih bot yang terdekat dan bergerak zig-zag menujunya sambil menyerang dengan serangan terkuat hingga bot tersebut sudah mati. <br /><br />
<b>3. Elsa (Greedy Swift Shooter) </b><br />
Elsa menerapkan algoritma yang menyerang cepat lalu kabur sebelum diserang balik. Pada algoritma ini, bot akan bergerak di arena dalam pola persegi. <br /><br />
<b>4. Moana (Wave Hunter) </b><br />
Moana menerapkan algoritma yang bergerak secara sinusoidal, menjaga jarak terhadap musuh, dan mengeluarkan tembakan berdasarkan jarak musuh.<br /><br />

## Struktur Program
```
Tubes1_biskitop/
├── doc/
│   ├── biskitop.txt
├── src/
│   ├── alternative-bots/
│   │   ├── Ariel/
│   │   ├── Elsa/
│   │   ├── Moana/
│   ├── Belle/
├── README.md
```

## Instalasi
1. **Install C# dan .NET**  
   - Unduh dan install .NET SDK dari Microsoft  
   - Pastikan C# sudah bisa digunakan dengan menjalankan:  
     ```bash
     dotnet --version
     ```
2. **Download dan Install Robocode Tank Royale**  
   - Unduh versi 0.30.0 dari [Robocode Tank Royale Releases](https://github.com/Ariel-HS/tubes1-if2211-starter-pack/releases/tag/v1.0)  
   - Ekstrak file yang diunduh ke folder pilihan  

## Cara Menjalankan
1. Clone repository ini dengan menjalankan perintah di bawah ini pada terminal IDE yang mendukung C# dan dotNET:
   ```sh
   git clone https://github.com/shanlie20/Tubes1_biskitop.git
2. Buka folder hasil clone di IDE.
3. Pindah ke directory Robocode Tank Royale diekstrak:
4. Jalankan di terminal :
   ```sh
   java -jar robocode-tankroyale-gui-0.30.0.jar
5. Klik ``Config``
6. Klik ``Boot Root Directories``
7. Klik ``Add`` dan pilih direktori bot yang ingin digunakan (yang telah diclone dan yang dari asisten), lalu klik ``OK``
8. Klik ``Battle``, lalu klik ``Start Battle``
9. Pilih mode yang ingin digunakan
10. Pilih bot-bot yang ingin dideploy
11. Tekan ``Boot``, tekan ``Add All``, dan ``Start Battle``
12. Robocode Tank Royale akan berjalan dan klik ``X`` untuk menutup hasil pertandingan
