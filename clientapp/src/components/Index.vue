<template>
    <div class="top-content">
        <h1>Kudos</h1>
    </div>
    <div class="container">
        <div class="content">
            <div class="left-content">
                <nav class="navbar navbar-light bg-light mb-4">
                    <ul class="navbar-nav">
                        <li class="nav-item active">
                            <a class="nav-link active" href="#">Home<span class="sr-only">(Current)</span></a>
                        </li>
                        <li class="nav-item active">
                            <a class="nav-link" href="#">Tags</a>
                        </li>
                        <li class="nav-item active">
                            <a class="nav-link" href="#">All</a>
                        </li>
                    </ul>
                </nav>
            </div>
            <div class="right-content">
            </div>
        </div>
    </div>
</template>

<style scoped>
    html, body {
        margin: 0;
        padding: 0;
        height: 100%;
        width: 100%;
    }

    .container {
        padding: 0;
        height: 100vh;
        width: 100vw;
        display: flex;
        flex-direction: column;
    }

    .top-content {
        position: absolute;
        top: 10px;
        left: 10px;
    }

    .content {
        margin-top: 60px;
    }

    .left-content {
        position: absolute;
        left: 12px;
        top: 70px;
        margin: 0;
    }

    .top-content {
        padding: 10px 0;
    }

    .sep {
        height: 2px;
        background-color: #ccc;
        width: 100%;
        margin: 10px 0;
    }
</style>









<script>
    //create logout button clear sesstion storage for logout and redirect to login
</script>
