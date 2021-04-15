$(document).on('click', '.accHeader', function () {
    if ($(this).hasClass('activeHead')) {
      $(this).next().slideToggle(500);
      $(this).toggleClass("activeHead")
      $(this).children('i').toggleClass('fa-angle-up')
      $(this).children('i').toggleClass('colorDefault');
      $(this).children('a').toggleClass('colorDefault');
      return;
    }
    let headersNext = [];
    headersNext = $('.accBody').toArray();
    let iS = [];
    iS = $('.accHeader i').toArray();
    let headers = [];
    headers = $('.accHeader').toArray();
    let headersA = [];
    headersA = $('.accHeader a').toArray();
    for (let i = 0; i < headersNext.length; i++) {
      $(headersNext[i]).slideUp(500);
      $(iS).removeClass('fa-angle-up')
      $(headersA).removeClass('colorDefault');
      $(iS).removeClass('colorDefault')
      $(headers).removeClass('activeHead')

    }

    $(this).children('a').addClass('colorDefault');
    $(this).children('i').addClass('colorDefault');
    $(this).addClass("activeHead")
    $(this).next().slideDown(500);
    $(this).children('i').addClass('fa-angle-up')

  })