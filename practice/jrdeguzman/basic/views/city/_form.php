<?php

use yii\helpers\Html;
use yii\helpers\ArrayHelper;
use yii\widgets\ActiveForm;
use app\models\Province;

/* @var $this yii\web\View */
/* @var $model app\models\City */
/* @var $form yii\widgets\ActiveForm */
?>

<div class="city-form">

    <?php $form = ActiveForm::begin(); ?>

    <?= $form->field($model, 'city_code')->textInput(['maxlength' => 32]) ?>

    <?= $form->field($model, 'city_description')->textInput(['maxlength' => 32]) ?>

    <?= $form->field($model, 'citycol')->textInput(['maxlength' => 45]) ?>

    <?= $form->field($model, 'province_id')->dropdownList(
			ArrayHelper::map(Province::find()->all(), 'id', 'province_description'),
			['prompt'=>'Choose a province'])
			?>

    <div class="form-group">
        <?= Html::submitButton($model->isNewRecord ? 'Create' : 'Update', ['class' => $model->isNewRecord ? 'btn btn-success' : 'btn btn-primary']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>
