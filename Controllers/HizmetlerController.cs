﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Collections.Specialized.BitVector32;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.Threading;
using System;

namespace KuaforWebSitesi.Controllers
{
    public class HizmetlerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
//< !DOCTYPE html >
//< html lang = "en" >
//< head >
//    < meta charset = "UTF-8" >
//    < meta name = "viewport" content = "width=device-width, initial-scale=1.0" >
//    < link rel = "stylesheet" href = "~/css/hizmetler.css" asp - append - version = "true" />
//    < link rel = "stylesheet" href = "~/css/fontFamily.css" asp - append - version = "true" />
//</ head >
//< body >
//    < div class= "hizmetler" >
//        < h1 > SERVİSLERİMİZ </ h1 >
//        < div class= "wrapper active" >
//            < div class= "text" >
//                < h1 > SAÇ ŞEKİLLENDİRME </ h1 >
//                < table >
//                    < thead >
//                        < tr >
//                            < th > Hizmet </ th >
//                            < th > Fiyat </ th >
//                        </ tr >
//                    </ thead >
//                    < tbody >
//                        < tr >
//                            < td > FÖN </ td >
//                            < td > 400 ₺</ td >
//                        </ tr >
//                        < tr >
//                            < td > MAŞA </ td >
//                            < td > 800 ₺ </ td >
//                        </ tr >
//                        < tr >
//                            < td > ÖRGÜ </ td >
//                            < td > 1000 ₺ </ td >
//                        </ tr >
//                        < tr >
//                            < td > TOPUZ </ td >
//                            < td > 1200 ₺ </ td >
//                        </ tr >
//                        < tr >
//                            < td > SAÇ KESİM </ td >
//                            < td > 1300 ₺ </ td >
//                        </ tr >
//                    </ tbody >
//                </ table >
//            </ div >
//            < div class= "photo" >
//                < img src = "~/web/images/hizmetler/sacSekillendir.jpg" alt = "sacSekillendirme" >
//            </ div >
//        </ div >

//        < div class= "wrapper" >
//            < div class= "photo" >
//                < img src = "~/web/images/hizmetler/sacBoyama.jpg" alt = "team" >
//            </ div >

//            < div class= "text" >
//                < h1 > SAÇ BOYAMA </ h1 >
//                < table >
//                    < thead >
//                        < tr >
//                            < th > Hizmet </ th >
//                            < th > Fiyat </ th >
//                        </ tr >
//                    </ thead >
//                    < tbody >
//                        < tr >
//                            < td > CİLA </ td >
//                            < td > 2500₺</ td >
//                        </ tr >
//                        < tr >
//                            < td > DİP BOYA </ td >
//                            < td > 1250₺</ td >
//                        </ tr >
//                        < tr >
//                            < td > TRANSPARAN BOYA </ td >
//                            < td > 1750₺ </ td >
//                        </ tr >
//                        < tr >
//                            < td > BÜTÜN BOYA </ td >
//                            < td > 2500₺</ td >
//                        </ tr >
//                        < tr >
//                            < td > BRUSHLIGHT </ td >
//                            < td > 5500₺</ td >
//                        </ tr >
//                        < tr >
//                            < td > HIGHLIGHT / LOWLIGHT / BALYAJ / OMBRE / SOMBRE </ td >
//                            < td > 6000₺</ td >
//                        </ tr >
//                        < tr >
//                            < td > Röfle </ td >
//                            < td > 8000₺</ td >
//                        </ tr >
//                        < tr >
//                            < td > SAKİNLEŞTİRİCİ BAKIM </ td >
//                            < td > 4000₺</ td >
//                        </ tr >
//                        < tr >
//                            < td > DÜZLEŞTİRİCİ BAKIM </ td >
//                            < td > 6000₺</ td >
//                        </ tr >

//                    </ tbody >
//                </ table >
//            </ div >

//        </ div >

//        < div class= "wrapper" >
//            < div class= "text" >
//                < h1 > GELİN </ h1 >
//                < table >
//                    < thead >
//                        < tr >
//                            < th > Hizmet </ th >
//                            < th > Fiyat </ th >
//                        </ tr >
//                    </ thead >
//                    < tbody >
//                        < tr >
//                            < td > GELİN SAÇ </ td >
//                            < td > 6000₺</ td >
//                        </ tr >
//                        < tr >
//                            < td > GELİN MAKYAJ </ td >
//                            < td > 6000₺</ td >
//                        </ tr >
//                    </ tbody >
//                </ table >
//            </ div >
//            < div class= "photo" >
//                < img src = "~/web/images/hizmetler/gelin.jpg" alt = "team" >
//            </ div >
//        </ div >


//        < div class= "wrapper" >
//            < div class= "photo" >
//                < img src = "~/web/images/hizmetler/manikur.jpg" alt = "team" >
//            </ div >
//            < div class= "text" >
//                < h1 > MANİKÜR & PEDİKÜR </ h1 >
//                < table >
//                    < thead >
//                        < tr >
//                            < th > Hizmet </ th >
//                            < th > Fiyat </ th >
//                        </ tr >
//                    </ thead >
//                    < tbody >
//                        < tr >
//                            < td > MANİKÜR </ td >
//                            < td > 750₺</ td >
//                        </ tr >
//                        < tr >
//                            < td > PEDİKÜR </ td >
//                            < td > 750₺</ td >
//                        </ tr >
//                        < tr >
//                            < td > EL KALICI OJE</td>
//                            <td>550₺</td>
//                        </tr>
//                        <tr>
//                            <td>AYAK KALICI OJE</td>
//                            <td>750₺</td>
//                        </tr>
//                    </tbody>
//                </table>
//            </div>

//        </div>
//        <div class= "wrapper" >


//            < div class= "text" >
//                < h1 > CİLT </ h1 >
//                < table >
//                    < thead >
//                        < tr >
//                            < th > Hizmet </ th >
//                            < th > Fiyat </ th >
//                        </ tr >
//                    </ thead >
//                    < tbody >
//                        < tr >
//                            < td > PROFESYONEL CİLT BAKIMI</td>
//                            <td>2500₺</td>
//                        </tr>
//                        <tr>
//                            <td>KAŞ ALIMI</td>
//                            <td>400₺</td>
//                        </tr>
//                        <tr>
//                            <td>KİRPİK LİFTİNG</td>
//                            <td>1250₺</td>
//                        </tr>
//                        <tr>
//                            <td>KARBON PEELİNG</td>
//                            <td>1500₺</td>
//                        </tr>
//                    </tbody>
//                </table>
//            </div>
//            <div class= "photo" >
//                < img src = "~/web/images/hizmetler/cilt.jpg" alt = "team" >
//            </ div >

//        </ div >
//    </ div >
//    @section Scripts {
//        @{
//            await Html.RenderPartialAsync("_ValidationScriptsPartial");
//        }
//    }
//    < script src = "~/js/scroll1.js" ></ script >

//</ body >

//</ html >