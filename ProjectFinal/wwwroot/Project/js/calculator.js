$(document).ready(function(){
    $(document).on('click','.clickedDropdown',function(){
        var dropdowns = $('.clickedDropdown').toArray();

        for(var i = 0;i<dropdowns.length;i++){
            $(dropdowns[i]).removeClass('redSelected');
        }
        $(this).addClass('redSelected');
       
        
        $(this).parent().parent().prev().html($(this).html());

    });
    $(document).on('click','.hesablaButton',function(){
        var recentResult;
        var country=$(".countryButton").html();
        country=country.replace(/\s/g, '')
        
        var kqText=$('.kqcustomMain').html();
        kqText=kqText.replace(/\s/g, '');
        console.log(kqText);
        var amount= $('.customAmount').val();
        var kqValue=$('.CustomCekiInput').val();
        

        if(country=='Türkiyə'){
            if(kqText=='qram'){
                
             
                if(kqValue>0&&kqValue<=250){
                    recentResult=2;
                }else  if(kqValue>250&&kqValue<=500){
                    recentResult=3;
                }else  if(kqValue>500&&kqValue<=700){
                    recentResult=4;
                }else if(kqValue>700&&kqValue<=999){
                    recentResult=4.5;
                }else{
                    console.log(kqValue/1000)
                    recentResult=(kqValue/1000)*4.5;
                }
                console.log(recentResult*amount)
                recentResult=recentResult*amount
            }else{
                recentResult=kqValue*4.5;
                recentResult=recentResult*amount

            }
        }else if(country=='Amerike'){
            if(kqText=='qram'){
                
             
                if(kqValue>0&&kqValue<=250){
                    recentResult=1.99;
                }else  if(kqValue>250&&kqValue<=500){
                    recentResult=3.99;
                }else  if(kqValue>500&&kqValue<=700){
                    recentResult=4.99;
                }else if(kqValue>700&&kqValue<=999){
                    recentResult=5.99;
                }else{
                    console.log(kqValue/1000)
                    recentResult=(kqValue/1000)*5.99;
                }
              
                recentResult=recentResult*amount
                console.log(recentResult)
            }else{
                recentResult=kqValue*5.99;
                recentResult=recentResult*amount
                console.log(recentResult)

            }
        }
        $('.finalAmount').html(recentResult);
        
        
       
        
    });
    $(document).on('click','.customCalcReset',function(){
        $('.CustomCekiInput').val('');
        $('.customAmount').val('');
        $('.customEnInput').val('');
        $('.customUzunlugInput').val('');
        $('.customHundurlukInput').val('');
        $('.finalAmount').html('0,00')


    })
   
})