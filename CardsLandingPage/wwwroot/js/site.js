// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//Cards landing page
const parralax = document.getElementById("parallax")

window.addEventListener("scroll", function () {
    let offset = window.pageYOffset
    parralax.style.backgroundPositionY = offset * 0.8 + "px"
   
})

//AdminDashBoard Page
const tabs = document.querySelectorAll('[data-tab-target]')
const tabContents = document.querySelectorAll('[data-tab-content')

tabs.forEach(tab => {
    tab.addEventListener('click', () => {
        const target = document.querySelector(tab.dataset.tabTarget)
        tabContents.forEach(tabContent => tabContent.classList.remove('active'))
        tabs.forEach(tab => tab.classList.remove('active'))
        target.classList.add('active')
        tab.classList.add('active')
    })
})

